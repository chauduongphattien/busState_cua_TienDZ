   M S B A M L   `   `   `  ����C  ?busState, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:busState.viewbusState.view  5   	   "    busState.view.changepassFrom   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:busState.view     5   	   
������   � Title$  changepassFrom��5	   	   $	��300��6    $	��400��6-   .��5
      � .+�5   
   �� $��0q�6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �    winBorderColor1 � Color# [  6#    � Offset$ 0Q�6L   � 5        winBorderColor2# [ 6#   $	 0.5Q�6L   � 5        winBorderColor3# [ 6#   $ 1Q�6L   5      ._�5      �  � RowDefinitions 5      �� 5      $��3* �6$   �� 5      $��1* �6$   �� 5      $��1* �6$   .+�5      � $��0��6    5      �� 5      �� 5      .+�5       �� $��Center=�6!   $��Center=�6<   $��0��6Y    �� Orientation$ 
Horizontal=�6f   .+�5!      �� $��Mật khẩu mới��6    �� 5"      -   5         ��Name$ 
txtNewPass��5"   3   $��5,0,0,0q�6"   $	��100��6G   5$      �� 5%      $ 
Horizontal=�6!   $��Center=�5&   !   $��Center=�5'   !   $��1��5(   !   .+�5)      �� $��Xác nhận��6    �� 5*      -   5        $ 
txtXacNhan��5*   4   $��30,0,0,0q�6"   $	��100��6H   5+      5,      � 5.      $��1��6   $��0,10,0,0q�6$    � ColumnDefinitions 5/      �� 50      �� 51      .+�53      �� -   5        	 ��Name$	 btnOK��54   7   $��0��53      $	��100��6-   $��OK��69   
��� � �$��16(�54      $��30��6+   
�������55      �� 56      -   5        $	 btnHUY��58   )   $��1��56      $��16(�57      $��30��58      $	��100��59      $��Hủy��6)   
��� ���
�������6K   5:      �� 5<      -   5        
 ��Name$
 LBnotfy��5=   q   $��Center=�5<      $	��Top=�5=      $	��Top=�6-   $��2��6L   $�� ��6Y   $��30��6e   
���  ��$��0,20,0,0q�6�   5?      5A      5B      5C      