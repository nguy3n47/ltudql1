   M S B A M L   `   `   `  ����I  EDashboardAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DashboardAdminDashboardAdmin  5      +    %DashboardAdmin.TransactionUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:DashboardAdmin     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � 	Resources  5      .   (DashboardAdmin.ByteArrayToImageConverter   byteArrayToImage#   DashboardAdmin.PriceConverter  PriceConverter��%:   &	        &	        5   
   6*     5   
   6   5      .��5      ]� 
���������. .+�5   
   �� $��40��5      $��Center=�5      $	��Top=�5       �� Orientation$ 
Horizontal=�5      .+�5      �� -   5        $��addPurchaseButton��5      $��80��5      $��30��5      $��5,0,0,0q�5      .��5      �� $ 
Horizontal=�6   .+�5      �� $��20��5      $��20��5       �� BitmapScalingMode$ HighQuality=�5       $��/Images/add.png��5!      �� 5"      $��5,0,0,0q�5#      $��Center=�5$      $	��Add��5%      5&      5'      �� 5(      $��24��5)      $��5,0,5,0q�5*       �� Padding$ 2q�5+      $��Từ ngày:��5,      (  "System.Windows.Controls.DatePicker  5-      -   5        $��fromDatePicker��5.      $	��120��5/      $��30��50         Text$  ��51      &   System.Windows.Media.TextOptions   TextHintingMode$ Fixed=�52      �� 53      $��24��54      $��5,0,5,0q�55      $ 2q�56      $��Đến ngày:��57        58      -   5        $��toDatePicker��59      $	��120��5:      $��30��5;      �� 5<      $��24��5=      $��5,0,5,0q�5>      $ 2q�5?      $ ��Trạng thái đơn hàng:��5@      �� 5A      -   5        $��purchaseStatesComboBox��5B      $	��100��5C      $��30��5D      $��5,0,5,0q�5E      ��5F      �� 5G      .R�5H      �� $ 3q�6$   ��60   �� *Key+5I      5K      �� 5L      $ 
Horizontal=�6   .+�5M      �� $��25��5N      $��10,5,5,5q�5O      $ HighQuality=�5P      $"��/Images/magnifying-glass.png��5Q      �� 5R      $	��150��5S      $��30��5T      $��5,5,0,0q�5U      5V      �� 5W      $��20,0,0,0q�5X      $��Center=�5Y      $ 
Horizontal=�5Z      .+�5[      �� -   5        $��80��5\      $��30��5]      $��0,0,10,0q�5^      $��Previous��5`      �� 5a      -   5        $��pagesComboBox��5b      $	��100��5c      $��30��5d      ��5f      �� 5g      .R�5h      �� $��Center=�6)   $ 
Horizontal=�6F   .+�5i   "   �� $ 4q�6,   $
��Page��68   �� 5j   "   $	 0,4q�6,   ��6:   �� *Page+�� 5k   "   $	 0,4q�6,   $	�� / ��6:   �� 5l   "   $	 0,4q�6,   ��6:   �� *
TotalPages+5m      5n      5p      �� 5q      -   5        $��80��5r      $��30��5s      $��10,0,0,0q�5t      $
��Next��5v      5w      5x      ]� 5y   
   ��. .+�5z      &   System.Windows.Controls.DataGrid  -	   5        $��purchaseDataGrid��5{         AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Mã đơn hàng��6E   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6)   �� *	OrderID+6E     5�      $	 Tên khách hàng��6F   
 6)   �� *
Fullname+6F     5�      $	 Số điện thoại��6A   
 6)   �� *Tel+6A     5�      $	 Ngày tạo��6G   
 6)   �� *	CreatedAt+6G     5�      $	 Tổng tiền��6n   
 6)   �� *Total+ �� 	Converter# [ 6n     5�      $	 Trạng thái đơn hàng��6D   
 6)   �� *Status+6D    � ContextMenu 5�      �� 5�      .@�5�      m� -
   5        $
��Edit��5�   G    m� Icon 5�      �� 5�   "   $��16��5�   %   $��16��5�   %   $ HighQuality=�5�   %   $��/Images/edit.png��5�   %   5�      m� 5�      -   5        $��Delete��5�   I    5�      �� 5�   "   $��16��5�   %   $��16��5�   %   $ HighQuality=�5�   %   $��/Images/x-button.png��5�   %   5�      5�         RowDetailsTemplate 5�      �� 5�      .R�5�      ]� 
�������.+�5�      �� $��64��5�   !   $��10q�5�   !   $
��Left=�5�   !   $ HighQuality=�5�   !   $=��7https://www.pngrepo.com/download/44105/shopping-bag.png��5�   !   � 5�      $
��0,10q�6#    � ColumnDefinitions 5�   "   �� 5�   &   $
��Auto �67   �� 5�   &   $��* �67    � RowDefinitions 5�   "   �� 5�   &   $
��Auto �64   �� 5�   &   $
��Auto �64   �� 5�   &   $
��Auto �64   .+�5�   "   �� $
��Bold"�6,   $��	OrderID: ��6>   �� 5�   "   $��1��6,   ��6<   �� *	OrderID+�� 5�   "   $��1��5�   %   $
��Bold"�5�   %   $��Name: ��5�   %   �� 5�   "   $��1��5�   %   $��1��5�   %   ��5�   %   �� *
Fullname+�� 5�   "   $��2��5�   %   $
��Bold"�5�   %   $��Tel: ��5�   %   �� 5�   "   $��2��5�   %   $��1��5�   %   ��5�   %   �� *Tel+5�      5�      5�      5�      �� 5�      -   5        $��purchaseStackPanel��5�      
���  ��$��Right=�5�      .+�5�        $	��500��6   ��6(   ��  �� ElementName$ purchaseDataGrid�� �� Path$ SelectedItem.Details�5�      5�      5�      5�      