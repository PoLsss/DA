   M S B A M L   `   `   `  ����?  ;QLKS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLKSQLKS  5   	   A%clr-namespace:QLKS.UserControlProcessQLKS.UserControlProcess  5   	       QLKS.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:QLKS     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   .uc%clr-namespace:QLKS.UserControlProcess  5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          �Name$  mainwindows��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    
 MainVM � DataContext# [ 5   	    � WindowStyle$
 None=�5   	   $��1q�5   
   
����+�� � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .  � Title$ Quản lý khách sạn��5   	   $	��700��6#   $
��1300��60    � 	Resources 5        	CloseMenu	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  OpenMenu��%  &	       &	 �     �� 5    
   .��5!      U� $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $
 grdMenu��6�   .\�5"        $ 0��6'   $	 250Q�63     5#      $ 0:0:0.3��6'   $ 0Q�69   5$      5%      �� 5&   
   .��5'      U� $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $
 grdMenu��6�   .\�5(        $ 0��6'   $ 0Q�63     5)      $ 0:0:0.3��6'   $	 250Q�69   5*      5+      5,       � Triggers 5/      :� 50   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ btnCloseLVMenu��66   .[�51      �� -   5         ��Name$ CloseMenu_BeginStoryboard��51      #��[ 6A   52      :� 53   
   $ ButtonBase.Click��6   $ btnOpenLVMenu��66   .[�54      �� #��[ 6   55       J� Clip 58      �� 59   
    �� Rect$ 0,0,1300,700�6    �� RadiusX$ 10Q�60    �� RadiusY$ 10Q�6=   -   5        	boGoc��5:      .��5<      �  � RowDefinitions 5=   
   �� 5>      $��26 �6   6*   �� 5?      6   .+�5C   
   *   $QLKS.UserControlProcess.ControlBarUC  $��0��6   $��Center=�5D   N   ��5C   (   �� *MinHeight_ucControlbar+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�
 � Tag 5D      �� *Title+ �� ElementName$ mainwindows��5E      � 5G   
   $��1��6   .+�5J      � -   5         �Name$ GridBackground��5J       5K      �� 5L      $��30 �6$   62   �� 5M      6&   .+�5P      (  "MaterialDesignThemes.Wpf.ColorZone  -   5          Name$ titleBar��5Q   .   ���	#FFF4F4F4$��30��5P   F   $��0��6R   .��5R      �  � ColumnDefinitions 5S      �� 5T      $
��auto �6/   6>   �� 5U      $��1* �6/   6<   �� 5V      $	��210 �6/   6=   .+�5Y      ��  �� Orientation$ 
Horizontal=�6%   $��0��6>   $��5 0 0 0 q�6N   .+�5[      �� -   5         ��Name$ btnOpenLVMenu��5\   %   $��30��5[   %   
������ $��0q�5\   U   $��0q�6i   .��5]   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Menu=�6:   
���   �$��30��6Y   $��30��6d   5^      5`      � 5b      $��1��6   .+�5c      �� $��Center=�6)   $��40 0 0 0q�6D   $��20(�5d   E   ��6)   �� *
Title_Main+6E   5e      � 5f      $��2��6   .+�5h      '  !MaterialDesignThemes.Wpf.PopupBox  $��	 0 0 40 0q�66   $��Right=�6I       PopupContent.  5i   "   �� .@�5j   &   �� $��Hello World��62   �� 5k   &   $��
Nice Popup��62   �� 5l   &   $��Information��62   5m   #   5n      5o      5q      5s      � 5u      -   5        $ displayMain��5u      $��1��5v       5w      �� 5x      $	��20* �6(   �� 5y      $	��39* �6(   �� 5z      $
��102* �6(   .+�5|      �� -   5        ! ��Name$! contenDisplayMain��5|   %   $
��auto��5}   )   $
��auto��5~   )   $��3��67   5      5�      � 5�      -	   5        $ grdMenu��5�      $	��250��5�      
�������$
��Left=�5�      $��
-250 0 0 0q�5�      " J� RenderTransformOrigin$" 0.5,0.5&�5�      z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�       5�      �� 5�      $
��Auto �6$   �� 5�      $��* �6$   .+�5�      � $��0��6   $	��170��6$   .+�5�      � ���	#FF142C2F.+�5�      �� -
   5        $ btnDangXuat��5�   !   $��80��66   $��30��6A   $
��Left=�6M   $��0q�6h   
���k���$	��Top=�5�   !   $��11(�69   $��0q�6H   
������ 
�������.��5�      �� $��Đăng xuất��6(   ���	#FFE4EAF369   5�      A� 5�      -   5        # A�Name$# 	imgAvatar��5�   "   $	��130��65   $	��130��6A   $	��Top=�6N   $��0 10 0 0q�6f   ��5�      �� 5�   "   $ �� ImageSource$$ /Anh/Emma0.jpg��6-   5�      � 5�      -   5        $ 	grdAvatar��5�      $	��130��62   $	��130��6>   $	��Top=�6L   $��0 10 0 0q�6d    5�      �� 5�   "   $ 0,0,130,130�64   $ 65Q�6G   $ 65Q�6T   .+�5�      �� -   5        % ��Name$% txblAvatarBinding��5�   (   �� 5�      -   5        $ 
btnThayAnh��5�   %   $��Bottom=�69   
�������& J� Opacity$	& 0.6Q�6g   $��0q�5�   %   $��30��69   ��5�   "   �� 5�   &   ' �� 
TargetType"' ��6,   .�5�   *   �� ( �� Property( � y�) �� Value$) Hidden=�6G   6X   * �� Triggers* 5�   *   �� 5�   .   + �� Binding+ 6:   �� $ txblAvatarBinding��, �� Path$, IsMouseOver�- �� Value- True6~   .a�5�   2   �� ( � y�$) Visible=�6O   6a   5�   /   P� 5�   .   . P� Property. �@J�IsMouseOver/ P� Value/ . . �5�   2   �� ( � y�$) Visible=�6O   6a   5�   /   5�   '   .��5�   "     $	& 0.8Q�6:   $ CameraImage=�6H   
����  �$��20��6m   $��20��6x   5�      5�      �� 5�      -   5        $% 
txbHoTenNV��5�   $   $��Nguyen Thanh Thien Qua��68   $��18(�6V   $��0 0 0 4q�6d   $��Center=�5�   $   $��Bottom=�6A   ���	#DDDFE9F7$��Oboto)�6�   ��6s   Z� 6�   5�      �� 5�      -   5        $ btnCloseLVMenu��5�      $��30��5�      $��40��6)   $	��Top=�64   $��Right=�6L   
������ $��0q�5�   N   $��0q�6b   .��5�        $ ChevronTripleLeft=�62   ���	#FFE2D7D7$��40��6b   $��30��6m   5�      5�      �� 5�      -   5        0 ��Name$0 lisviewMenu��5�      $��1��5�      ���	#FF313131$��Champagne & Limousines)�6A   $��18(�6i   $��Hidden=�5�      $��Hidden=�5�      ��. ��5�      �� 5�      .R�5�      �� $ 
Horizontal=�6)   $
��10 0q�6B   .+�5�   "     $��20��6U   $��20��6`   $��5q�6�   $��Center=�6�    6:   �� *	kind_Icon+��6l   �� *	foreColor+6�   �� 5�   "   $��10q�6B   ��6,   �� *name+6B   5�      5�      5�      5�      5�      5�      5�      