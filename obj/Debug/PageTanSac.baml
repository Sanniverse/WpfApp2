   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5          WpfApp2.PageTanSac   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp2     5        N� Title$  
PageTanSac��5	      .��5      � .+�5   
   �� $��Source\background.png��6   $��UniformToFill=�6/   6I   �� 5   
   $��Tan sac��6   $��30(�6#   $��Center=�61   $��Center=�6N   � 5   
   -   5         �Name$ 
AdjustMenu��5      $	��200��6#   $��Right=�6/   $��
0,-685,0,0q�6K   .+�5      �� -   5        $��80��5      $��35��5      $��100,650,0,0q�5      $	��Top=�5      
������ 
������ ��5      �� 5      $ ��Source\adjustmenupick3.png��6   6B   5      �� 5      $��Source\adjustmenu.png��6   $	��Top=�5      $��	0,-20,0,0q�5      $	��700��5      $
��Fill=�5      5      �� 5       $	��Top=�6   $��0,30,0,0q�5!      $	��150��5"      $��Source\vitri2.png��5#      5$      �� 5%      -   5         ��Name$	 tbx��5%      $��40��5&      $	��120��5'      $��	40,60,0,0q�5(      
������  J� 	AllowDrop .   �� TextAlignment$ Center=�5*   (   $��Ink Free)�6?   $	��Top=�6U   $
��Bold"�6m   $��20(�6   $��
10,5,10,10q�6�   .��6�   ��5+      �� 5,       �� ImageSource$ /Source/otrong.png��6!   .��5-   &   5.      �� 5/      -   5        $	 tby��5/      $��40��50      $	��120��51      $��
40,100,0,0q�52      
������  .  $ Center=�54   (   $��Ink Free)�6?   $	��Top=�6U   $
��Bold"�6m   $��20(�6   $��
10,5,10,10q�6�   .��6�   ��55      �� 56      $ /Source/otrong.png��6!   .��57   &   58      �� 59      $	��Top=�6   $
��Left=�5:      $��
25,160,0,0q�5;      $	��100��5<      $��Source\goc.png��5=      5>      �� 5?      $	��Top=�6   $��Center=�5@      $��
-5,200,0,0q�5A      $	��170��5B      $��Source\3090.png��5C      5D      �� 5E      -   5         ��Name$ mySlider��5E       � Minimum$ 0Q�6'    � Maximum$ 90Q�63   	 � Value$	 30Q�6@   
 �� TickFrequency$
 5Q�5F       �� IsSnapToTickEnabled . $	��Top=�5G      $	��105��5H      $��
-5,200,0,0q�5I      �� 5J      -   5         ��Name$ sliderValueText��5J      $	��Top=�5L      $��Center=�6,   $��	0,220,0,0q�5M      $��16(�6'   $��Ink Free)�65   $
��Bold"�6K   ���#252257��5K      ��  �� ElementName$ mySlider�� �� Path$ Value�5M   ]   5N      5O       � 	Resources 5P         ShowMenuStoryboard �� 
TargetName �� TargetProperty	 t� To g� Duration  HideMenuStoryboard��%  &	        &	 ~     �� 5Q   
   .��5R      t� $ 
AdjustMenu��6!   $ Margin�5S      $ 0,0,0,0X�5T      $ 0:0:0.5D�6   5U      �� 5V   
   .��5W      t� $ 
AdjustMenu��6!   $ Margin�5X      $ 
0,-685,0,0X�5Y      $ 0:0:0.5D�6   5Z      5[      5\      