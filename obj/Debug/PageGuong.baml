   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5          WpfApp2.PageGuong   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp2     5        N� Title$  	PageGuong��5	      .��5      � .+�5   	   �� $��Source\background.png��6   $��UniformToFill=�6.   6H   �� 5   
   $��Guong��6   $��30(�6!   $��Center=�6/   $��Center=�6L   � 5   
   -   5         �Name$ 
AdjustMenu��5      $	��200��6#   $��Right=�6/   $��
0,-685,0,0q�6K   .+�5      �� -   5        $��80��5      $��35��5      $��100,650,0,0q�5      $	��Top=�5      
������ 
������ ��5      �� 5      $ ��Source\adjustmenupick3.png��6   6B   5      �� 5      $��Source\adjustmenu.png��6   $	��Top=�5      $��	0,-20,0,0q�5      $	��700��5      $
��Fill=�5      5      �� 5       -   5         ��Name$ 
GuongPhang��5       $	��Top=�5!      $��0,30,0,0q�5"      
������ 
������ $	��150��5%      ��5&      �� 5'       �� 
TargetType" ��6   .�5(      ��  �� Property � �� �� Value 5)   "   �� 5*   &   $��Source\txtguongphang3.png��6,   5,       �� Triggers 5-      P� 5.       P� Property �@J�IsMouseOver P� Value . . �5/   "   ��  � �� 50   &   �� 51   *   $��Source\guongphangudl.png��60   53   #   54      56      58      �� 59      -   5        $ GuongCauLoi��59      $	��Top=�5:      $��0,70,0,0q�5;      
������ 
������ $	��150��5>      ��5?      �� 5@      " ��6   .�5A      ��  � �� 5B      �� 5C   "   $ ��Source\txtguongcauloi3.png��6(   5E       5F      P� 5G       �@J�IsMouseOver . . �5H   "   ��  � �� 5I   &   �� 5J   *   $��Source\guongcauloiudl.png��60   5L   #   5M      5O      5Q      �� 5R      -   5        $ GuongCauLom��5R      $	��Top=�5S      $��	0,110,0,0q�5T      
������ 
������ $	��150��5W      ��5X      �� 5Y      " ��6   .�5Z      ��  � �� 5[      �� 5\   "   $ ��Source\txtguongcaulom3.png��6(   5^       5_      P� 5`       �@J�IsMouseOver . . �5a   "   ��  � �� 5b   &   �� 5c   *   $��Source\guongcaulomudl.png��60   5e   #   5f      5h      5j      5k      5l      	 � 	Resources	 5m         ShowMenuStoryboard
 �� 
TargetName �� TargetProperty	 t� To g� Duration  HideMenuStoryboard��%  &	        &	 ~     �� 5n   
   .��5o      t� $
 
AdjustMenu��6!   $ Margin�5p      $ 0,0,0,0X�5q      $ 0:0:0.5D�6)   5r      �� 5s   
   .��5t      t� $
 
AdjustMenu��6!   $ Margin�5u      $ 
0,-685,0,0X�5v      $ 0:0:0.5D�6,   5w      5x      5y      