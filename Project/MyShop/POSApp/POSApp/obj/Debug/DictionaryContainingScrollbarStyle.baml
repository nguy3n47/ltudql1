   M S B A M L   `   `   `  ����A  =POSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:POSAppPOSApp  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollBarTrackThumb  �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      localclr-namespace:POSApp  5      %�	  &	        '�� �    �� 5      "  n�6(   .�5   
   ��  � �� 5      �� 5      " n�6"   .R�5	      � $
 Grid��6   .+�5
      �� $
��Auto��5      $
��Auto��5      $��Stretch=�5      $��Stretch=�5      
������ 5      �� 5      $ CornerScrollBarRectangle��5      $
��Auto��5      $
��Auto��5      $��0,1,0,1q�5      $��Stretch=�5      $��Stretch=�5      #��z��5      $ 5��5      5       5      P� 5       �@�Tag$	 
Horizontal��61   . �5      �� $
 CornerScrollBarRectangle��6%    � ��$
 Auto��6\   �� 5      $
 CornerScrollBarRectangle��6%    � ��$ 6��6]   5      5       5"      5#      �� 5$      "  ��6   .�5%   
   ��  �@��IsFlicksEnabled .  63   �� 5&   
    � �� �#ADABAB6'   �� 5'   
    � ��
 ���� 6'   �� 5(   
    � ��$ 7��6"   �� 5)   
    � �� 5*      �� 5+      " ��6"   .R�5,      � $ GridRoot��5-      $��7��5.      #��z��5/       50      �� 51      $��0.00001* �6,   .+�53      ]� $ 
PART_Track��54      $��0��55      |�.  ��.  58      n� 59   "   $ Thumb��5:   %   #��z��5;   %   #���   5<   %    5>      �� 5?   "   $ PageUp��5@   %   $��ScrollBar.PageDownCommand��5A   %   |�.  $ 0Q�5C   %    5E      �� 5F   "   $ PageDown��5G   %   $��ScrollBar.PageUpCommand��5H   %   |�.  $ 0Q�5J   %   5L      5M       5N      P� 5O      $ Thumb��6"    �@J�IsMouseOver	 . . �5P      �� $
 Thumb��6%   # �  6N    � ��5Q      P� 5R      $ Thumb��6"    �@n�
IsDragging	 . . �5S      �� $
 Thumb��6%   # �  6N    � ��5T      P� 5V       � {�	 .  . �5W      �� $
 Thumb��6%    � y�$ 	Collapsed=�6N   5X      P� 5Y       �@��Orientation$	 
Horizontal=�69   . �5Z      �� $
 GridRoot��6%    �@�LayoutTransform 5[   "   �� 5\   &   $	 -90Q�66   5^      �� 5_      $
 
PART_Track��6%    �@�LayoutTransform 5`   "   �� 5a   &   $	 -90Q�66   5c      �� 5d       � ��$
 Auto��66   �� 5e       � ��$ 8��67   �� 5f      $
 Thumb��6%    �@�Tag$ 
Horizontal��6G   �� 5g      $
 PageDown��6%    � ��$ ScrollBar.PageLeftCommand��6N   �� 5h      $
 PageUp��6%    � ��$  ScrollBar.PageRightCommand��6L   5i      5k      5m      5n      5o      