   M S B A M L   `   `   `  ����?  ;QLKS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLKSQLKS  5   	   A%clr-namespace:QLKS.UserControlProcessQLKS.UserControlProcess  5
   	       QLKS.DialogCustoms   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:QLKS     5   	   4uc%clr-namespace:QLKS.UserControlProcess     5
   	   -   5          �Name$  dialogcustom��5   	    � Title$ DialogCustoms��5	      $	��180��6   $	��400��6+    � WindowStyle$
 None=�5   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� ImageSource$ /Anh/backgroud.jpg��6    j� Stretch$
 Fill=�66    J� Clip 5      �� 5   
    �� Rect$ 0,0,400,180�6   	 �� RadiusX$	 10Q�6/   
 �� RadiusY$
 10Q�6<   .��5      �� $��1q�6   ���	#FF807D7D �� CornerRadius$ 10��69   ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��103* �6#   �� 5      $
��287* �6#    � RowDefinitions 5      �� 5      $��26 �6    6.   �� 5      6"   .+�5       *   $QLKS.UserControlProcess.ControlBarUC  $��0��6    J� Opacity$	 0.8Q�5!   L   $��Center=�6Z   $��26��6u   $��2��6�   ��5    +   �� *MinHeight_ucControlbar+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�
 � Tag 5!      �� *Title+ �� ElementName$ dialogcustom��5"      � 5%      $��1��6   $��2��6     5&      �� 5'      6&   �� 5(      $��50 �6$   62   .+�5*      � $��0��6   .+�5+      �� -   5         ��Name$ txblMess��5+       $��12(�62    �� TextAlignment$ Center=�6@   $��Center=�6W   $��DemiBold"�6r   $��WrapWithOverflow=�6�   6�   5,      � 5-      $��1��6   .+�5.      �� -   5         ��Name$ btnYes��5.      $��70��6-   $��30��68   ���	#FF49886C$
��_Yes��6[   $
��Left=�5/      $��Center=�64   $��80 0 0 0q�6O   $��12(�6a    50      �� 51      $ 	0,0,70,30�60   $	 10Q�6A   $
 10Q�6N   53      �� 54      -   5        $ btnNo��54      $��70��6,   $��30��67   ���	#FF6D7764$	��_No��6Z   $��Right=�55      $��Center=�65   $��0 0 80 0q�6P   $��12(�6b   
������� 56      �� 57      $ 	0,0,70,30�60   $	 10Q�6A   $
 10Q�6N   59      �� 5:      -   5        $ btnOK��5:      $��70��6,   $��30��67   ���	#FF49886C$	��_OK��6Z   $��Center=�5;      $��Center=�66   $��12(�6Q    5<      �� 5=      $ 	0,0,70,30�60   $	 10Q�6A   $
 10Q�6N   5?      5@      5A      5B      5C      5D      