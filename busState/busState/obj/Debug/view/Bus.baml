   M S B A M L   `   `   `  ����C  ?busState, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:busState.viewbusState.view  5          busState.view.Bus   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:busState.view     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5        N� 
Background
  ����  N� Title$	 Bus��5      .��5      � .+�5   
   �� .+�5      � $��40��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6.   .+�5      �� -   5         ��Name$ maxeTXT��5   1   $��5,0,0,0q�5      $��50��6/   $��20��6:   
������ 
�������
�������5   1   �� 5      -   5         ��Name$ timkiem��5      $��5,0,5,0q�6D   
������ $��0q�5      .��5      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�6'      
Foreground
 �����$��10��6H   $��20��6S   5      �� 5       $��Tìm kiếm bằng mã xe��6   $��Center=�6:   $��Center=�5!      
�������$��
Montserrat)�5"        5#      $	 Bus=�6#   
 �� ��$��20��6B   $��20��6M   $��5,0,0,0q�5$   #   5%      5(      �� 5)      $
��Auto=�6   $	��350��6@   $
��Auto=�5*      .��5+      �� -   5         ��Name$ listviewBus��5+      	 �� SelectionMode$	 Single=�61   
 �� View
 5,      �� 5-      ! �� ColumnHeaderContainerStyle 5/      �� 50   "    �� 
TargetType" ��6(   .�51   &   ��  �� Property � �� �� Value
 �����6C   �� 52   &    � ��
 �����6C   �� 53   &    � ��$ Roboto)�6C   �� 54   &    � ��$ 1,0,1,0q�6H   �� 55   &    � ��$ Center=�6S   56   #   .P�58      ��  �� CellTemplate 59   "   �� 5:   &   .R�5<   .     $	 Bus=�6;   
 ��  �$��20��6X   $��20��6c   5>   '   5@      �� 5B      $��Mã Xe��6-    �� Width$ 50��6<    �� DisplayMemberBinding 6G   �� *Maxxe+6p   �� 5C      $��Tuyến��6-   $ 50��6<    6G   �� *Tuyen+6p   �� 5D      $��	Tài Xế��6-   $	 200��6=    6I   �� *
TenTaiXe+6u   �� 5E      $��Phụ Xe��6-   $	 200��6=    6I   �� *
TenPhuXe+6u   �� 5F      $��Bến Xuấ Phát��6-   $ 50��6C    6N   �� *
Xuatphat+6z   �� 5G      $��Trạng Thái��6-   $ 80��6A    6L   �� *	Trangthai+6y   5I      5L      5M      � 5N      $��0,10,0,0q�6   $��Center=�6%    5O      �� 5P      �� 5Q      �� 5R      .+�5V      �� -   5        $ conHDBtn��5V   A   $��0��6   $	��150��6)   $��30��65   $��Xe không còn HĐ��5W      
���   �
�������$��Center=�5X      5Y      �� 5Z      -   5        $ 	seeallBtn��5Z   A   $��1��6   $	��150��6)   $��30��65   $��Xem Tât Cả��5[      
���   �
�������$��Center=�5\      5]      �� 5^      -   5        $ themBtn��5^   A   $��2��6   $	��150��6)   $��30��65   $��Thêm��5_      
���   �
�������$��Center=�5`      5a      5d      5e      5f      5g      