   M S B A M L   `   `   `  ����I  EDashboardAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DashboardAdminDashboardAdmin  5   	   M IFluent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent 5   	       DashboardAdmin.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DashboardAdmin     5   	   7Fluent$clr-namespace:Fluent;assembly=Fluent     5   	   -   5          � Title$  
MainWindow��5	   	   $	��800��6   $
��1280��6)    � WindowStartupLocation$ CenterScreen=�66    � 	Resources 5
      .   (DashboardAdmin.ByteArrayToImageConverter   byteArrayToImage#   DashboardAdmin.PriceConverter  PriceConverter��%:   &	        &	        5   
   6E     5   
   6   5      .��5      ]� ��. .+�5   
     Fluent.Ribbon  $	��Top=�6      Menu 5        Fluent.Backstage  5        Fluent.RibbonControl   Header$ My Shop��6#      Content. 5         Fluent.BackstageTabControl  .@�5        Fluent.BackstageTabItem     Header$
 Info��62   .��5      �� $
��INFO��6$   5        5      -   5        $
 Exit��5   2   6@   5      5         Tabs. 5        Fluent.RibbonTabItem     Header$ Master data��6#   	   Groups.	 5      	  Fluent.RibbonGroupBox	  $��Import��6(   .@�5      
  Fluent.Button
  -   5        
 
  Header$
 Excel��5   $    
  	LargeIcon 5      �� 5      $��/Images/excel.png��6$    �� BitmapScalingMode$ HighQuality=�6?   5!      5"      	  5#      $��Category��6(   .@�5$      
  -   5        $	
 Add��5$   $    5%      �� 5&      $��/Images/plus.png��6$   $ HighQuality=�6>   5(      
  5)      -   5        $
 Update��5)   $    5*      �� 5+      $��/Images/update.png��6$   $ HighQuality=�6@   5-      
  5.      -   5        $
 Delete��5.   $    5/      �� 50      $��/Images/cancel.png��6$   $ HighQuality=�6@   52      53      	  55      $��Product��6(   .@�56      
  -   5        $	
 Add��56   $    57      �� 58      $��/Images/add.png��6$   $ HighQuality=�6=   5:      
  5;      -   5        $
 Update��5;   $    5<      �� 5=      $��/Images/edit.png��6$   $ HighQuality=�6>   5?      
  5@      -	   5        $
 Delete��5@   $    5A      �� 5B      $��/Images/x-button.png��6$   $ HighQuality=�6B   5D      5E      5G        5I      $
 Sale��6#   5J        5L      $ Report��6#   5M      5N      ]� 5O   
   .+�5P      �� -
   5        $��status��5P      $��Bottom=�6&   $��40��6>   .@�5R      �� -   5        $��statusLabel��5R      $	��400��6+   5T      ]� 5U      .+�5V      ��  �� Orientation$ 
Horizontal=�6   $��40��66   $	��Top=�6B   .+�5W      �� -   5        $��categoriesComboBox��5W   L   $	��200��6f   $��30��6r   $��
8, 0, 0, 0q�6~   ��5X      �� 5Y      .R�5Z   "   �� .+�5[   &   ��  �� Padding$ 3, 4, 0 , 0q�60   
����  �$
��Bold"�6X   ��6j   �� *Name+5\   #   5]      5_      �� 5`      $ 
Horizontal=�6!   .+�5a      �� $��10,5,5,5q�6    $ HighQuality=�62   $"��/Images/magnifying-glass.png��6`   $��25��6�   �� 5b      -   5         ��Name$ keywordTextBox��5b   7   $��
5, 5, 0, 0q�6"   $��30��6x   $	��400��6�   5c      �� 5d      $ 
Horizontal=�6!   .+�5e      �� -   5        $��filter��5e       $��Images/filter.png��6_   $
��Left=�6z   $��30��6�   $��30��6�   $ HighQuality=�6�   $��10,0,0,0q�6�   6�   �� 5f      $��Center=�6$   5g      5h      �� 5i      $��40��6   $��Bottom=�6)   
��� � �5k      � 5l      $��40��6   $��Bottom=�6#    � ColumnDefinitions 5m      �� 5n      6-   �� 5o      6-   .+�5q      � $��0��6   $��10 0 0 0q�6+   $
��Left=�6=   .+�5r      �� -   5        $��statusTextBlock��5r   0   $ 8q�6$   $	��300��6G   $��16(�6S   6c   5s      �� 5t      $��2��6!   $��40��65   $ 
Horizontal=�6A   $��Center=�6Z   .+�5u      �� -   5        $��Previous��5u   !   $��80��6Q   $��0,0,10,0q�6\   6p   �� 5v      -   5        $��pagesComboBox��5v   /   $	��100��6#   ��5w      �� 5x   "   .R�5y   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�5z   *   �� $
��Page��64   $ 8q�6@   �� 5{   *   $	 0,8q�6J   ��64   �� *Page+6J   �� 5|   *   $	�� / ��64   $	 0,8q�6?   �� 5}   *   $	 0,8q�6P   ��64   �� *
TotalPages+6P   5~   '   5   #   5�      �� 5�      -   5        $
��Next��5�   !   $��80��6I   $��10 0 0 0q�6T   6h   5�      5�      ]� 5�      .+�5�      �� -   5        $��filterOptions��5�   !   $y�Visible=�66   
���  ��$
��Left=�6\   $	��180��6r    K� ZIndex$ 1��6~   .+�5�      �� $ 8q�6$   $
��Giá��60   
�������$��18(�6N   6^   �� 5�      -   5        $��listViewPriceFilter��5�   #   ��5�      �� 5�   "   .R�5�   &   �� .+�5�   *   �� $��18(�64   ��6B   �� *Text+5�   '   5�   #   5�      �� 5�      -   5        $��unselectFilter��5�   !   $
��0 10q�6T   $��30��6b   $��16(�6n   $	��110��6|   $��Unselect Filter��6�   6�   5�      �� 5�      -   5        $��productsListView��5�      $��Hidden=�67   $��Disabled=�6j   
���   ���5�      �� 5�      .R�5�   "   � 6.   5�      ��5�      �� 5�      .R�5�   "   �� .+�5�   &   �� $	��305��6�   $	��305��6�   $��UniformToFill=�6�   $ HighQuality=�6�   ��6,   �� *	Thumbnail+ �� 	Converter# [   �� Mode$ OneTime=�6�   �� 5�   &   $��18(�60   $��Center=�6b   $��Center=�6   ��6>   �� *Name+$ OneTime=�6   �� 5�   &   $��18(�60   
���  ��$��Center=�6�   $��Center=�6�   ��6O   �� *Price+# [ $ OneTime=�6�   5�   #   5�      5�      5�      5�      5�      5�      5�      