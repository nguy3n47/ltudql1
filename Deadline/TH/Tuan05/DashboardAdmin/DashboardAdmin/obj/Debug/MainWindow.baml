   M S B A M L   `   `   `  ����I  EDashboardAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DashboardAdminDashboardAdmin  5   	   M IFluent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent 5   	       DashboardAdmin.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DashboardAdmin     5   	   7Fluent$clr-namespace:Fluent;assembly=Fluent     5   	   -   5          � Title$  
MainWindow��5	   	   $	��800��6   $
��1280��6)    � WindowStartupLocation$ CenterScreen=�66    � 	Resources 5
      .   (DashboardAdmin.ByteArrayToImageConverter   byteArrayToImage��%   &	          5   
   6E   5      .��5      ]� ��. .+�5   
     Fluent.Ribbon  $	��Top=�6      Menu 5        Fluent.Backstage  5        Fluent.RibbonControl   Header$ My Shop��6#      Content. 5         Fluent.BackstageTabControl  .@�5        Fluent.BackstageTabItem     Header$
 Info��62   .��5      �� $
��INFO��6$   5        5      -   5        $
 Exit��5   2   6@   5      5         Tabs. 5        Fluent.RibbonTabItem     Header$ Master data��6#   	   Groups.	 5        Fluent.RibbonGroupBox  $��Import��6(   .@�5      	  Fluent.Button	  -   5        
 	  Header$
 Excel��5   $    	  	LargeIcon 5      �� 5      $��/Images/excel.png��6$    �� BitmapScalingMode$ HighQuality=�6?   5       5!        5"      $��Category��6(   .@�5#      	  -   5        $	
 Add��5#   $    5$      �� 5%      $��/Images/plus.png��6$   $ HighQuality=�6>   5'      	  5(      -   5        $
 Delete��5(   $    5)      �� 5*      $��/Images/cancel.png��6$   $ HighQuality=�6@   5,      5-        5/      $��Product��6(   .@�50      	  -   5        $	
 Add��50   $    51      �� 52      $��/Images/add.png��6$   $ HighQuality=�6=   54      	  55      -   5        $
 Update��55   $    56      �� 57      $��/Images/edit.png��6$   $ HighQuality=�6>   59      	  5:      -   5        $
 Delete��5:   $    5;      �� 5<      $��/Images/x-button.png��6$   $ HighQuality=�6B   5>      5?      5A        5C      $
 Sale��6#   5D        5F      $ Report��6#   5G      5H      ]� 5I   
   .+�5J      �� -	   5        $��status��5J      $��Bottom=�6&   $��40��6>   .@�5L      �� -
   5        $��statusLabel��5L      $	��400��6+   5N      ]� 5O      .+�5P      ��  �� Orientation$ 
Horizontal=�6   $��40��66   $	��Top=�6B   .+�5Q      �� -   5        $��categoriesComboBox��5Q   L   $	��200��6f   $��30��6r   $��
8, 0, 0, 0q�6~   ��5R      �� 5S      .R�5T   "   �� .+�5U   &   ��  �� Padding$ 3, 4, 0 , 0q�60   
����  �$
��Bold"�6X   ��6j   �� *Name+5V   #   5W      5Y      �� 5Z      .+�5[      �� $ HighQuality=�6    $"��/Images/magnifying-glass.png��6N   $��16��6t   $��16��6    �� Left$ 18��6�   
 �� Top$ 12��6�    K� ZIndex$ 10��6�   �� 5\      -   5         ��Name$ keywordTextBox��5\   8   $��30, 5, 0, 0q�6"   $��30��6y   $	��400��6�   $��10, 5, 0 , 0q�6�   5]      5^      �� 5_      $��40��6   $��Bottom=�6)   
��� � �5a      � 5b      $��40��6   $��Bottom=�6#    � ColumnDefinitions 5c      �� 5d      6-   �� 5e      6-   .+�5g      � $��0��6   $��20 0 0 0q�6+   $
��Left=�6=   .+�5h      �� -   5        $��statusTextBlock��5h   0   $ 8q�6$   $	��300��6G   $��16(�6S   6c   5i      �� 5j      $��2��6!   $��40��65   $ 
Horizontal=�6A   $��Center=�6Z   .+�5k      �� -   5        $��Previous��5k   !   $��80��6Q   $��0,0,10,0q�6\   6p   �� 5l      -   5        $��pagesComboBox��5l   /   $	��100��6#   ��5m      �� 5n   "   .R�5o   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�5p   *   �� $
��Page��64   $ 8q�6@   �� 5q   *   $	 0,8q�6J   ��64   �� *Page+6J   �� 5r   *   $	�� / ��64   $	 0,8q�6?   �� 5s   *   $	 0,8q�6P   ��64   �� *
TotalPages+6P   5t   '   5u   #   5w      �� 5x      -   5        $
��Next��5x   !   $��80��6I   $��10 0 0 0q�6T   6h   5y      5z      �� 5{      -   5        $��productsListView��5{      $��Hidden=�63   $��Disabled=�6f   
���   ���5|      �� 5}      .R�5~      � 6*   5      ��5�      �� 5�      .R�5�      �� .+�5�   "   �� $	��305��6�   $	��305��6�   $��UniformToFill=�6�   $ HighQuality=�6�   ��6(   �� *	Thumbnail+ �� 	Converter# [   �� Mode$ OneTime=�6�   �� 5�   "   $��18(�6,   $��Center=�6^   $��Center=�6{   ��6:   �� *Name+$ OneTime=�6{   5�      5�      5�      5�      5�      5�      5�      