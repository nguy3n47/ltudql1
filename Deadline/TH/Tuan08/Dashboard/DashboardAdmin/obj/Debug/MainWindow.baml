   M S B A M L   `   `   `  ����I  EDashboardAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DashboardAdminDashboardAdmin  5   	   M IFluent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent 5   	       DashboardAdmin.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DashboardAdmin     5   	   7Fluent$clr-namespace:Fluent;assembly=Fluent     5   	   -   5          � Title$  
MainWindow��5	   	   $	��800��6   $
��1280��6)    � WindowStartupLocation$ CenterScreen=�66    � 	Resources 5
      .   (DashboardAdmin.ByteArrayToImageConverter   byteArrayToImage#   DashboardAdmin.PriceConverter  PriceConverter��%:   &	        &	        5   
   6E     5   
   6   5      .��5      ]� ��. .+�5   
     Fluent.Ribbon  -   5        $��ribbon��5      $	��Top=�6&      Menu 5        Fluent.Backstage  5        Fluent.RibbonControl   Header$ My Shop��6#      Content. 5         Fluent.BackstageTabControl  .@�5        Fluent.BackstageTabItem     Header$
 Info��62   .��5      �� $
��INFO��6$   5        5      -   5        $
 Exit��5   2   6@   5      5         Tabs. 5        Fluent.RibbonTabItem     Header$ Master data��6#   	   Groups.	 5      	  Fluent.RibbonGroupBox	  $��Import��6(   .@�5      
  Fluent.Button
  -   5        
 
  Header$
 Excel��5   $    
  	LargeIcon 5      �� 5      $��/Images/excel.png��6$    �� BitmapScalingMode$ HighQuality=�6?   5!      5"      	  5#      $��Category��6(   .@�5$      
  -   5        $	
 Add��5$   $    5%      �� 5&      $��/Images/plus.png��6$   $ HighQuality=�6>   5(      
  5)      -   5        $
 Update��5)   $    5*      �� 5+      $��/Images/update.png��6$   $ HighQuality=�6@   5-      
  5.      -   5        $
 Delete��5.   $    5/      �� 50      $��/Images/cancel.png��6$   $ HighQuality=�6@   52      53      	  55      $��Product��6(   .@�56      
  -   5        $	
 Add��56   $    57      �� 58      $��/Images/add.png��6$   $ HighQuality=�6=   5:      
  5;      -	   5        $
 Update��5;   $    5<      �� 5=      $��/Images/edit.png��6$   $ HighQuality=�6>   5?      
  5@      -
   5        $
 Delete��5@   $    5A      �� 5B      $��/Images/x-button.png��6$   $ HighQuality=�6B   5D      5E      5G        5I      $
 Sale��6#   5J        5L      $ Transaction��6#   .	 5M      	  $
��Data��6(   .@�5N      
  $	
 New��6$    5O      �� 5P      $��/Images/add.png��6$   $ HighQuality=�6=   5R      
  5S      $

 Eidt��6$    5T      �� 5U      $��/Images/edit.png��6$   $ HighQuality=�6>   5W      
  5X      $
 Delete��6$    5Y      �� 5Z      $��/Images/x-button.png��6$   $ HighQuality=�6B   5\      
  5]      $
 Refresh��6$    5^      �� 5_      $��/Images/refresh.png��6$   $ HighQuality=�6A   6q   5a      5b      5c        5e      $ Report��6#   5f      5g      �� 5i   
   -   5        $��tabsContent��5i       �� SelectedIndex 6(   ��  �� ElementName$ ribbon�� �� Path$ SelectedTabIndex�5k      5l      5m      