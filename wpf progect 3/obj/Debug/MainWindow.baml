   M S B A M L   `   `   `  ����H  Dwpf progect 3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:wpf_progect_3wpf_progect_3  5   	       wpf_progect_3.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:wpf_progect_3     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Вход��5	   	   $	��600��6   $	��700��6#   .��5
      � -   5         �Name$ MainRoot��5
      
�������.+�5   
   �� $��Chossku Desk��6   $��50(�6(   $��0 0 0 20q�66   
���   �$
��Bold"�6[   $��Arial Black)�6m   $��Center=�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 50Q�6#      Color$ White��63      ShadowDepth$ 11Q�6A   5      �� 5   
   $	��400��6   $��20q�6!   
�������$��Center=�6@    �� Padding$ 20q�6[   $��40��6h    �� CornerRadius$ 20��6v    5        5      $ 50Q�6#   $ Purple��63   $ 0Q�6B   ._�5      �� .+�5      �� $&�� Добро пожаловать!��6   $��30(�65   $
��Bold"�6C   $��0 0 0 20q�6U   � 5      $��0 0 0 20q�6   .+�5      �� $
��Left=�6   $��Регистрация��68   �� 5      -   5        $��Right=�5      $��Авторизация��69      MaterialDesignFlatButton#��[  6n   5      �� 5      -   5         ��Name$ loginBox��5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$ 	 Введите логин:��6,    % !MaterialDesignFloatingHintTextBox#��[ 6\   G� 5      -   5        
 G�Name$
 passwordBox��5      $"	 Введите пароль:��63    ) %MaterialDesignFloatingHintPasswordBox#��[ 6d   G� 5      -   5        $
 passwordBox_2��5      $&	  Повторите пароль:��65   #��[ 6h   �� 5      -   5        $ EmailBox��5      $	 Email:��6,   #��[ 6T   �� 5      -   5        $*��$Зарегистрироваться��5      $
��0 20q�66   6D   5       5!      5"      5#      