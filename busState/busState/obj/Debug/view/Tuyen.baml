   M S B A M L   `   `   `  ����C  ?busState, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:busState.viewbusState.view  5          busState.view.Tuyen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      'localclr-namespace:busState.view  5        N� 
Background
  ����  N� Title$ Tuyen��5      .��5      � .+�5   
   �� .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $
��Left=�6.   .+�5      �� -   5         ��Name$ 
combackbtn��5      $��40��61   
������ $��	10,10,0,0q�5      $��0q�60   .��5      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ LongArrowLeft=�6'      
Foreground
 �����6<   5      5      5      �� 5      $	��450��6   $��0,15,0,0q�6(   .��5      �� -   5         ��Name$ listviewtuyen��5       �� View 5       �� 5!      ! �� ColumnHeaderContainerStyle 5#      �� 5$   "   	 �� 
TargetType"	 ��6(   .�5%   &   �� 
 �� Property
 � �� �� Value
 ��+��6C   �� 5&   &   
 � ��
 �����6C   5(   #   .P�5+      �� $��ID��6-    �� Width$ 40��6b    �� DisplayMemberBinding 69   �� *	Matuyen+6b   �� 5,      $��Tuyến��6-   $	 100��6a    6<   �� *Ten+6a   �� 5-      $��Chuyến đầu��6-   $	 100��6h    6A   �� *Start+6h   �� 5.      $��Chuyến cuối��6-   $	 100��6g    6B   �� *End+6g   �� 5/      $��Xuất phát��6-   $	 100��6h    6@   �� *Bendau+6h   �� 50      $��Điểm đến��6-   $	 100��6h    6?   �� *	Bencuoi+6h   �� 51      $��Trạng thái��6-   $	 100��6l    6A   �� *	Trangthai+6l   52      54      55      � 57      $��0,10,0,0q�6    58      �� 59      �� 5:      �� 5;      .+�5=      �� -   5        $ tuyenNgungBtn��5>      $��0��5=      $��Tuyến ngưng HĐ��6)   $	��150��6B   $��30��6N   
�������
���   �5?      5@      5A      5B      5C      