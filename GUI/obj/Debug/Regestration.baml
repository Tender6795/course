   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	       GUI.Regestration   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:GUI     5   	     � Title$!  Выполните вход��5      $	��200��6   $	��400��6,   $	��400��68   $	��400��6G   $	��200��6V   $	��200��5	   	    � WindowStyle$ 
ToolWindow=�6   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      .+�5   
   �� $��16(�6   $��Center=�6   $
��10,0q�69   .��6G   
Логин6N   �� 5   
   $��1��6   $��16(�6   $��Center=�6+   $
��10,0q�6F   .��6T   Пороль6\   �� 5   
   -   5        $��TbLogin��5   "   $��1��6   $��5q�61   $��16(�6<   $��Center=�6J   $��User1��6e   6t   G� 5   
   -   5        $��
PbPassword��5   D    G� PasswordChar$ *��6   $��1��6'   $��1��67   $��5q�6V   $��16(�6a   6�   �� 5   
   -   5        $��CbShow��5      $��2��6!   $��16(�6.   $
��10,0q�6<   $��2��6J    d� IsThreeState .  .��6�   Показать пароль6�   �� 5   
   -   5        $��
TbPassword��5      $��1��6$   $��1��64   $��16(�6A   $��5q�6O   $y�Hidden=�6[   .��6�   1234566�   �� 5   
   $��1��6   $��3��6%    �� Orientation$ 
Horizontal=�62   .+�5      �� -   5        $��ButOk��5      $��Ok��6"   $��80��6/   $��14(�6:   $��5q�6H    �� 	IsDefault . 6d   �� 5      -   5        $��	ButCancel��5      $��Отмена��6&   $��80��67   $��14(�6B   $��5q�6P   �� 5      -   5        $��
ButRegistr��5      $��Регистрация��6'   $��90��6=   $��14(�6H   $��5q�6V   6a   5      5       5"      