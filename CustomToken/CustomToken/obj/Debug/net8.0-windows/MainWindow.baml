   M S B A M L   `   `   `  ����J  FCustomTokenTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CustomTokenCustomToken  5   	        CustomTokenTest.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:CustomToken     5   	   -   5          � Title$  CustomTokenTest��5   	   $	��650��6!   $
��1200��6.    � WindowStartupLocation$ CenterScreen=�6;   $
��Left=�6`   .��5	      � $	��632��6   $��Center=�6   $��0,1,0,1q�65   $
��1200��6F    � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dataGrid1��5      $	��920��6Q   $	��600��6]   $
��Left=�6j   $	��Top=�6�   $��10,0,0,0q�6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�      CanUserSortColumns$ False��6  6  �� 5   
   -   5         ��Name$ btnGenerateToken��5      $��Generate token��6+   $
��Left=�6D   $��936,152,0,0q�6_   $	��Top=�6t   $	��247��6�   $��20��6�   6�   �� 5   
   -   5         ��Name$ cmbPermission��5      $
��Left=�6*   $��1127,97,0,0q�6E   $	��Top=�6Z   $��56��6r    �� SelectedIndex$ 0��6}   	 J� RenderTransformOrigin$	 0.511,1.838&�6�   $��22��6�   �� 5   
   $��Permission:��6   $
��Left=�6&   $��
930,95,0,0q�6A   $	��Top=�6U   $��78��6m   $��26��6x   �� 5   
   $��
User name:��6   $
��Left=�6%   $��
930,70,0,0q�6@   $	��Top=�6T   $��26��6l   $��69��6x   �� 5   
   -   5        
 ��Name$
 txbUserName��5      $
��Left=�6'   $��
999,73,0,0q�6B    �� TextWrapping$
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��184��6�   $��19��6�   �� 5   
   $��User Id:��6   $
��Left=�6#   $��
930,18,0,0q�6>   $	��Top=�6R   $��26��6j   $��50��6v   �� 5   
   -   5        $
 	txbUserId��5      $
��Left=�6%   $��
935,47,0,0q�6@   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��248��6�   $��21��6�   �� 5   
   -   5        $��Generate Id��5      $
��Left=�6'   $��
999,22,0,0q�6B   $	��Top=�6V   $	��184��6n   $��18��6z   6�   �� 5   
   -   5        $
 txbVerification��5      $
��Left=�6+   $��936,196,0,0q�6F   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��247��6�   $��18��6�   6�   �� 5   
   -	   5        $ btnVerification��5      $��Token verification��6*   $
��Left=�6G   $��936,219,0,0q�6b   $	��Top=�6w   $	��247��6�   6�   �� 5   
   $��Expiration Time:��6   $
��Left=�6+   $��930,121,0,0q�6F   $	��Top=�6[   $	 0.577,0.206&�6s   �� 5   
   -
   5        $ cmbExpirationTime��5      $
��Left=�6.   $��1127,124,0,0q�6I   $	��Top=�6_   $��56��6w   �� 5   
   -   5        $
 tbxTokenValidity��5      $
��Left=�6,   $��936,246,0,0q�6G   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��247��6�   $��70��6�   5      5      