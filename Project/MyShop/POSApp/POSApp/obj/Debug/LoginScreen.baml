   M S B A M L   `   `   `  ����A  =POSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:POSAppPOSApp  5          POSApp.LoginScreen   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:POSApp     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      $
��1100��5	      $	��700��5
        � AllowsTransparency  . 
������    MaterialDesignFont#���   5       � Icon$ Assets/logo.ico��5       � 
ResizeMode$ NoResize=�5      $��13(�5      $��Regular"�5        MaterialDesignBody#���  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      �� 
�������$��0q�5   	    �� CornerRadius$ 30��5   	   ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��1.5* �6#   �� 5      .+�5!      �� $��0��6   $ 	30 0 0 30��6%   ��5"      �� 5#      	 �� ImageSource$	 Assets/banner_index_2.jpg��5$      
 �� BitmapScalingMode$
 HighQuality=�5%       j� Stretch$ UniformToFill=�5&      5(      ]� 5)      $��1��6   ��. .+�5*      �� $��Center=�5+      $��Center=�5,      $	��Top=�5-      .+�5.      �� $	��100��5/      $	��100��50      $ 50��51      ��52      �� 53      $1	 +Assets/36efaa1db4ee7a1a52a9a05f811670da.png��54   !   $
 HighQuality=�55   !   $ UniformToFill=�56   !   58      �� 59      $��	0,10,0,40q�5:      $��Center=�5;      $��Sign In��5<      $��48(�5=      $
��Bold"�5>      �� 5?      -   5        $��usernameTextBox��5@      $	��350��5A      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��5B         
IsFloating . .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ 	Collapsed=�5D         HasClearButton .    HasOutlinedTextField .    TextFieldCornerRadius$ 4��5G       �� AcceptsReturn . $��0q�5I      $��18(�5J      G� 5K      -   5        $��passwordTextBox��5L      $	��350��5M      $��0,20,0,0q�5N      $ Password��5O       . $ 	Collapsed=�5Q       .  . $ 4��5T      $��0q�5U      $��18(�5V      � 5W      $��0,5,0,0q�6    .+�5X      �� -   5        $��rememberCheckBox��5Y      $��Center=�5Z      $	��Top=�5[      $��Center=�5\      $��Stay signed in��5]      $��16(�5^      5_      � 5`      -   5        $��loginProgressBar��5a      $��30��5b      $��30��5c      $��0,10,0,0q�5d       � IsIndeterminate .   % !MaterialDesignCircularProgressBar#��[ 5f       � Value$ 0Q�5g      �� 5h      -   5        $��80��5i      $��80��5j      $��0,20,0,0q�5k       ( $MaterialDesignTextFieldBoxBackground#���  5l      
���   �$��18(�5o      
���   � �� 	IsDefault .   MaterialDesignIconButton#��[ 5r      .��5s      '  !MaterialDesignThemes.Wpf.PackIcon  $��40��5t      $��40��5u         Kind$ 
ArrowRight=�5v      5w      �� 5x      $��0,20,0,0q�5y      $��Center=�5z       � Cursor$
 Hand��5{      $��18(�5|      $��CAN'T SIGN IN?��5}      �� 5~      $��Center=�5      $
 Hand��5�      $��18(�5�      $��CREATE ACCOUNT��5�      �� 5�      $��0,20,0,0q�5�      $��Center=�5�      $
 Hand��5�      $��18(�5�      $��	V.1.0.0.0��5�      5�      5�      � 5�      $��1��5�      $��40��5�      $��
10,0,10,10q�5�      $��Bottom=�5�      .+�5�      �� -   5        $��40��5�      $��40��5�      $
��Left=�5�      #���  5�      
���   �$��18(�5�      
���   �#��[ 5�       � ToolTip$ MaterialDesignIconButton��5�      .��5�        $��30��5�      $��30��5�      $ Settings=�5�      5�      5�      5�      5�      5�      