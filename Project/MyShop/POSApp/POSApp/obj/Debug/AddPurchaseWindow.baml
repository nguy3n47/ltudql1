   M S B A M L   `   `   `  ����A  =POSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:POSAppPOSApp  5          POSApp.AddPurchaseWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:POSApp     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5          � Title$   ��5	      $��13(�5      $��Regular"�5         MaterialDesignBody#���   5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowState$ 	Maximized=�5       � 	Resources 5      &    POSApp.ByteArrayToImageConverter  byteArrayToImage   POSApp.PriceConverter  PriceConverter��%:   &	       &	        5   
   6*     5   
   6   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.8* �6   �� 5      .+�5   
   ]� $��0��6   ��. .+�5      �� $��60��5       $��20q�5!      $��Center=�5"      $��Center=�5#      $	��Top=�5$       �� Orientation$ 
Horizontal=�5%      .+�5&      �� -   5        $��categoriesComboBox��5'      $	��300��5(      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Category��5)      $��18(�5*         MaterialDesignFilledComboBox#��[ 5,      ��5-      �� 5.      .R�5/      �� .+�50   "   �� $��16(�51   %   $
��Bold"�52   %   ��53   %   �� *Category_Name+54      55      57      58      �� 59      $��80��5:      $��Center=�5;      $��Bottom=�5<      $ 
Horizontal=�5=      .+�5>      �� -   5        $��40��5?      $��40��5@      $��	10,0,10,0q�5A      
���   �
���   �  MaterialDesignIconButton#��[ 5E      .��5F      '  !MaterialDesignThemes.Wpf.PackIcon  $��20��5G      $��20��5H      
�������	   Kind$	 	ArrowLeft=�5J      5K      �� 5L      -   5        $��pagesComboBox��5M      $	��150��5N      $��40��5O      $��18(�5P      ��5R      �� 5S      .R�5T      � $��Center=�6(   .+�5U   "   �� $��Page ��6,   �� 5V   "   ��6,   �� *Page+�� 5W   "   $	�� / ��6,   �� 5X   "   ��6,   �� *
TotalPages+5Y      5Z      5\      �� 5]      -   5        $��40��5^      $��40��5_      $��	10,0,10,0q�5`      
���   �
���   �#��[ 5d      .��5e        $��20��5f      $��20��5g      
�������$	 
ArrowRight=�5i      5j      5k      �� 5l      -   5        $��productsListView��5m      
���   �$��Disabled=�5p      $��Visible=�5q      ��5r      �� 5s      
 �� 
TargetType"
 ��6   .�5t      -   5        5u      ��5w      �� 5x      .R�5y      � 5z      ��5|      �� 5}      .R�5~      �� .+�5      �� $	��305��5�   !   $	��305��5�   !    �� BitmapScalingMode$ HighQuality=�5�   !   $��UniformToFill=�5�   !   ��5�   !   �� *	Thumbnail+ �� 	Converter# [  �� Mode$ OneTime=�5�   !   �� 5�      $��Center=�5�   !   $��Center=�5�   !   $��18(�5�   !   ��5�   !   �� *Name+$ OneTime=��� 5�      $��Center=�5�   !   $��Center=�5�   !   $��18(�5�   !   
���   ���5�   !   �� *Price+# [ $ OneTime=�5�      5�      5�      5�      �� 5�   
   $��1��6   ���#FAFAFA.��5�      ]� ��. .+�5�      �� $��80��5�      $��	20,0,20,0q�5�      $	��Top=�5�      $ 
Horizontal=�5�      .+�5�      �� $��50��5�      $��50��5�       �� CornerRadius$ 50��5�      ��5�      �� 5�       �� ImageSource$1 +Assets/36efaa1db4ee7a1a52a9a05f811670da.png��5�   !   $ HighQuality=�5�   !    j� Stretch$ UniformToFill=�5�   !   5�      �� 5�      $��5,0,0,0q�5�      $��Center=�5�      $��28(�5�      $��Bad Habits Store��5�      5�      � 5�      $��35��5�      $��	20,0,20,0q�5�      $	��Top=�5�       5�      �� 5�      $��2* �6+   �� 5�      �� 5�      .+�5�      � $��0��5�      $
��Left=�5�      $��Center=�5�      .+�5�      �� $��SẢN PHẨM��6$   5�      � 5�      $��1��5�      $��Center=�5�      $��Center=�5�      .+�5�      �� $��Số lượng��6$   5�      � 5�      $��2��5�      $��Right=�5�      $��Center=�5�      .+�5�      �� $��TỔNG��6$   5�      5�      �� 5�      -   5         ��Name$ selectedProductsListView��5�      $��	10,0,20,0q�5�      $��Stretch=�5�      $��Stretch=�5�      $	��Top=�5�      $��Disabled=�5�      $��Hidden=�5�      ��5�      �� 5�      .R�5�      �� 5�      ��5�      �� 5�      .R�5�      �  5�   "   �� 5�   &   $��2* �67   �� 5�   &   �� 5�   &   .+�5�   "   � $��0��6'   .+�5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� -	   5        $��30��5�   -   $��30��5�   -   $��0,0,5,0q�5�   -   $
��Left=�5�   -    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5�   -   ��5�   -   Z� ��5�   -   Z� .��5�   .     $��30��5�   1   $��30��5�   1   
���   �$	 CloseCircleOutline=�5�   1   5�   +   �� 5�   *   $��80��5�   -   $��80��5�   -   $
��Left=�5�   -   $ HighQuality=�5�   -   $��UniformToFill=�5�   -   ��5�   -   �� *Photo+# [ 5�   -   �� 5�   *   $��10,0,0,0q�65   $��Center=�6G   .+�5�   .   �� ��68   �� *Product_Name+�� 5�   .   ��68   �� *
Unit_Price+# [ 5�   +   5�   '   5�   #   � 5�   "   $��1��5�   %   $��Center=�5�   %   $��Center=�5   %   .+�5  &   �� .+�5  *   �� ��64   �� *
Quantity+5  '   5  #   � 5  "   $��2��5  %   $��Right=�5  %   $��Center=�5  %   .+�5	  &   �� .+�5
  *   �� $
��Bold"�5  -   
����  ���5  -   �� *
SubTotal+# [ 5  '   5  #   5     5     5     � 5     $��35��5     $��	20,0,20,0q�5     $	��Top=�5     .+�5     �� $
��Left=�5     $��Center=�5     $��TỔNG CỘNG��5     �� 5     -
   5        $��totalTextBlock��5     $��Right=�5     $��Center=�5     $
��Bold"�5      $��0 VNĐ��5!     5"     �� 5#     $��
20,0,20,20q�6   .+�5$     �� -   5         ��Name$ customerNameTextBox��5%     $��45��5&     $��0,0,0,15q�5'     $ Họ và tên��5(      �� AcceptsReturn . 
�������$��16(�5+      * &MaterialDesignOutlinedTextFieldTextBox#��[ 5,     � 5-      5.     �� 5/     $
��1.5* �6/   �� 50     .+�52     � $��0��6   .+�53     �� -   5        $ customerEmailTextBox��54  !   $��45��55  !   $��	0,0,10,15q�56  !   $ Email��57  !    . 
�������$��16(�5:  !   #��[ 5;  !   5<     � 5=     $��1��6   .+�5>     �� -   5        $ customerTelTextBox��5?  !   $��45��5@  !   $��0,0,0,15q�5A  !   $ Số điện thoại��5B  !    . 
�������$��16(�5E  !    �� 	MaxLength$ 10��5F  !   #��[ 5G  !   5H  !   5I     5J     �� 5K     -   5        $ customerAddressTextBox��5L     $��45��5M     $��0,0,0,15q�5N     $ Địa chỉ��5O      . 
�������$��16(�5R     #��[ 5S     � 5T     .+�5U     �� -   5        $	��130��5V     $��45��5W     $��Right=�5X     
���   �
���   �$��Hoàn thành��5\     
�������5]     5^     5_     5`     5a     5b     5c     