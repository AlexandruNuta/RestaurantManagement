   M S B A M L   `   `   `  ����H  DManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ManagementApp.ViewModelsManagementApp.ViewModels  5   	   #    ManagementApp.Views.AdminPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ManagementApp.ViewModels     5   	     � Title$  	AdminPage��5   	   $	��450��6   $	��700��6(    � DataContext 5
      -   'ManagementApp.ViewModels.AdminViewModel  5   
   .��5      ]� .+�5   
   �� $	��Top=�6   $��Admin Dashboard��6)   $��24(�6@   $
��Bold"�6N   
����ح�
������� �� TextAlignment$ Center=�6�    �� Padding$ 10q�6�   �� 5   
   $��Bottom=�6   $��© 2024 ManagementApp��6,   
����ح�
�������$ Center=�6r   $ 10q�6�   � 5   
    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��1��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��Center=�6\   .+�5      �� $��	Employees��6   $	��150��6\   $	��150��6h   $��10q�6u   $��18(�6�   
����ح���6-   �� *NavigateToEmployeesCommand+6�   �� 5       $��Products��6   $	��150��6Z   $	��150��6f   $��10q�6s   $��18(�6   
��������6,   �� *NavigateToProductsCommand+6�   �� 5!      $��Tables��6   $	��150��6V   $	��150��6b   $��10q�6o   $��18(�6{   
���������6*   �� *NavigateToTablesCommand+6�   �� 5"      $��Order Ticket��6   $	��150��6[   $	��150��6g   $��10q�6t   $��18(�6�   
���������60   �� *NavigateToOrderCommand+6�   5#      5$      5%      5&      