using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for PageTanSac.xaml
    /// </summary>
    public partial class PageTanSac : Page
    {
        private bool isMenuVisible = false;
        private bool isDragging = false;
        private Point anchorPoint; // Điểm gốc của chuột khi bắt đầu drag
        private Ellipse currentEllipse; // Ellipse đang được kéo
        private Line normalLine = new Line();
        double light_X;
        double light_Y;
        public PageTanSac()
        {
            InitializeComponent();
            Prism();
            LightRay.Visibility = Visibility.Collapsed;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isMenuVisible)
            {
                // Nếu menu đang hiển thị, ẩn nó
                Storyboard hideStoryboard = (Storyboard)FindResource("HideMenuStoryboard");
                hideStoryboard.Begin();
            }
            else
            {
                // Nếu menu không hiển thị, hiển thị nó
                Storyboard showStoryboard = (Storyboard)FindResource("ShowMenuStoryboard");
                showStoryboard.Begin();
            }

            // Đảo ngược trạng thái
            isMenuVisible = !isMenuVisible;
        }

        private void tbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void mySlider_valueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Prism();
        }
        private Point Get_midPoint(Point point1, Point point2)
        {
            return new Point((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2);
        }
        private void Prism()
        {

            var point = new Point(560, 200);
            double angle = mySlider.Value / 2 * Math.PI / 180;
            double dis = 400 * Math.Tan(angle);
            var point1 = new Point(560 - dis, 600);
            var point2 = new Point(560 + dis, 600);
            Triangle.Points = new PointCollection
            {
                point,
                point1,
                point2
            };
            Point? intersection = PageTanSac.CheckCollision(LightRay, Triangle);
            if (intersection.HasValue)
            {
                LightRay.X2 = intersection.Value.X;
                LightRay.Y2 = intersection.Value.Y;
            }
            EventChanged();
            double lX = double.Parse(tbx.Text);
            double lY = double.Parse(tby.Text);
            var light_source = new Point(lX, lY);
        }
        private Point light_dispersion(double indice, Color color, Vector normal, Point? intersection)
        {
            Vector lightRay = new Vector(LightRay.X1 - LightRay.X2, LightRay.Y1 - LightRay.Y2);
            normal.Normalize();
            lightRay.Normalize();
            double cos_i1 = Vector.Multiply(normal, lightRay);
            double incidience_angleInRadians = Math.Acos(cos_i1);
            double incidience_angleInDegrees = incidience_angleInRadians * (180 / Math.PI);
            double r1 = Math.Asin(Math.Sin(incidience_angleInRadians) / indice);
            // Tính vector khúc xạ
            Vector refractedRay = normal * (-Math.Cos(r1)) + (lightRay + normal * cos_i1) * Math.Sin(r1);
            refractedRay.Normalize();
            Point startPoint = intersection.Value;
            Point endPoint = new Point(
                  startPoint.X + refractedRay.X * 10000, // Tăng độ dài vector
                  startPoint.Y + refractedRay.Y * 10000
            );
            return endPoint;
        }
        private Point light_dispersion_outside(double indice, Color color, Vector normal, Point? intersection, Point? secondIntersection)
        {
            Vector incidentVector = new Vector(secondIntersection.Value.X - intersection.Value.X, secondIntersection.Value.Y - intersection.Value.Y);
            normal.Normalize();
            incidentVector.Normalize();
            double cos_r2 = Vector.Multiply(incidentVector, normal);
            double r2 = Math.Acos(-cos_r2);
            double i2 = Math.Asin(indice * (1 - Math.Sin(r2)));
            // Tính vector khúc xạ
            Vector refractedVector = normal * (-Math.Cos(cos_r2)) + (incidentVector + normal * i2) * Math.Sin(cos_r2);
            refractedVector.Normalize();
            Point endPoint = new Point(
                secondIntersection.Value.X + refractedVector.X * 1000,
                secondIntersection.Value.Y - refractedVector.Y * 1000
            );
            return endPoint;
        }
        private static Vector CalculateNormal(Point p1, Point p2)
        {

            Vector edge = new Vector(p2.X - p1.X, p2.Y - p1.Y);
            return new Vector(-edge.Y, edge.X);
        }
        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Ellipse ellipse)
            {
                currentEllipse = ellipse;
                isDragging = true;

                anchorPoint = e.GetPosition(MyCanvas);
                anchorPoint.X -= Canvas.GetLeft(ellipse) + ellipse.Width / 2;
                anchorPoint.Y -= Canvas.GetTop(ellipse) + ellipse.Height / 2;

                ellipse.CaptureMouse();
            }
        }
        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && currentEllipse != null)
            {
                Point mousePos = e.GetPosition(MyCanvas);
                double newX = mousePos.X - anchorPoint.X - currentEllipse.Width / 2;
                double newY = mousePos.Y - anchorPoint.Y - currentEllipse.Height / 2;

                light_X = newX;
                light_Y = newY;
                if (light_X < 250)
                {
                    Canvas.SetLeft(currentEllipse, newX);
                    Canvas.SetTop(currentEllipse, newY);
                }
                double X = Canvas.GetLeft(currentEllipse);
                double Y = Canvas.GetTop(currentEllipse);

                tbx.Text = X.ToString("F1");
                tby.Text = Y.ToString("F1");

                LightRay.X1 = X + currentEllipse.Width / 2;
                LightRay.Y1 = Y + currentEllipse.Height / 2;
                LightRay.Y2 = LightRay.Y1;

                EventChanged();
            }
        }
        private void EventChanged()
        {
            Point? intersection = PageTanSac.CheckCollision(LightRay, Triangle);
            if (intersection.HasValue)
            {
                MyCanvas.Children.OfType<Line>().Where(l => l.Tag != null && l.Tag.ToString() == "BendingLight").ToList().ForEach(l => MyCanvas.Children.Remove(l));
                MyCanvas.Children.OfType<Line>().Where(l => l.Tag != null && l.Tag.ToString() == "EmergentLight").ToList().ForEach(l => MyCanvas.Children.Remove(l));
                LightRay.X2 = intersection.Value.X;
                LightRay.Y2 = intersection.Value.Y;
                LightRay.Visibility = Visibility.Visible;
                Vector normal = CalculateNormal(Triangle.Points[0], Triangle.Points[1]); // Chọn các điểm phù hợp
                NormalLine.X1 = intersection.Value.X - normal.X * 10;
                NormalLine.Y1 = intersection.Value.Y - normal.Y * 10;
                NormalLine.X2 = intersection.Value.X + normal.X * 10;
                NormalLine.Y2 = intersection.Value.Y + normal.Y * 10;
                NormalLine.Visibility = Visibility.Visible;
                //xử lý khúc xạ trong lăng kính
                double[] indices = { 1.5, 1.52, 1.54, 1.56, 1.58, 1.6, 1.62 };
                Color[] colors = { Colors.Red, Colors.Orange, Colors.Yellow, Colors.Green, Colors.Blue, Colors.Indigo, Colors.Violet };
                for (int i = 0; i < indices.Length; i++)
                {
                    Point endPoint = light_dispersion(indices[i], colors[i], normal, intersection);
                    Line refractedLineTemp = new Line
                    {
                        X1 = intersection.Value.X,
                        Y1 = intersection.Value.Y,
                        X2 = endPoint.X,
                        Y2 = endPoint.Y
                    };
                    Point? secondIntersection = PageTanSac.CheckCollision(refractedLineTemp, Triangle);
                    if (secondIntersection.HasValue)
                    {
                        Vector secondNormal = CalculateNormal(Triangle.Points[0], Triangle.Points[2]); // Pháp tuyến tại cạnh thứ hai
                        Point secondPoint = secondIntersection.Value;
                        Point endPoint2 = light_dispersion_outside(indices[i], colors[i], secondNormal, intersection, secondIntersection);
                        Line bendingLight = new Line
                        {
                            X1 = intersection.Value.X,
                            Y1 = intersection.Value.Y,
                            X2 = secondIntersection.Value.X,
                            Y2 = secondIntersection.Value.Y,
                            Stroke = new SolidColorBrush(colors[i]),
                            StrokeThickness = 3,
                            Tag = "BendingLight"
                        };
                        MyCanvas.Children.Add(bendingLight);
                        Line bendingLight2 = new Line
                        {
                            X1 = secondPoint.X,
                            Y1 = secondPoint.Y,
                            X2 = endPoint2.X,
                            Y2 = endPoint2.Y,
                            Stroke = new SolidColorBrush(colors[i]),
                            StrokeThickness = 3,
                            Tag = "EmergentLight"
                        };
                        MyCanvas.Children.Add(bendingLight2);
                    }
                }
            }
            else
            {
                LightRay.X2 = MyCanvas.ActualWidth;
                LightRay.Y2 = LightRay.Y1;
                NormalLine.Visibility = Visibility.Hidden;
                MyCanvas.Children.OfType<Line>().Where(l => l.Tag != null && l.Tag.ToString() == "BendingLight").ToList().ForEach(l => MyCanvas.Children.Remove(l));
            }
        }
        private void MainCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging && currentEllipse != null)
            {
                isDragging = false;
                currentEllipse.ReleaseMouseCapture();
                currentEllipse = null;
            }
        }
        private static bool LineIntersects(Line line1, Point p1, Point p2, out Point intersection)
        {
            intersection = new Point();
            var x1 = line1.X1;
            var y1 = line1.Y1;
            var x2 = line1.X2;
            var y2 = line1.Y2;

            double denominator = (x1 - x2) * (p1.Y - p2.Y) - (y1 - y2) * (p1.X - p2.X);
            if (denominator == 0)
                return false;
            if (Math.Abs(denominator) < 1e-12)
                return false;
            double t = ((x1 - p1.X) * (p1.Y - p2.Y) - (y1 - p1.Y) * (p1.X - p2.X)) / denominator;
            double u = -((x1 - x2) * (y1 - p1.Y) - (y1 - y2) * (x1 - p1.X)) / denominator;

            if (t >= Math.Pow(10, -12) && (t <= 1 + 1 * Math.Pow(10, -12)) && (u >= -1 * Math.Pow(10, -12)) && u <= 1 + 1 * Math.Pow(10, -12))
            {
                intersection = new Point(x1 + t * (x2 - x1), y1 + t * (y2 - y1));
                return true;
            }
            return false;
        }
        public static Point? CheckCollision(Line line, Polygon polygon)
        {
            for (int i = 0; i < polygon.Points.Count; i++)
            {
                Point p1 = polygon.Points[i];
                Point p2 = polygon.Points[(i + 1) % polygon.Points.Count];

                if (LineIntersects(line, p1, p2, out Point intersection))
                {
                    return intersection;
                }
            }
            return null;
        }
    }
}