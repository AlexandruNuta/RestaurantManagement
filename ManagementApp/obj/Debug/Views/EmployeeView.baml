   M S B A M L   `   `   `  ����H  DManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ManagementApp.ViewModelsManagementApp.ViewModels  5   	   &     ManagementApp.Views.EmployeeView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ManagementApp.ViewModels     5   	     � Title$  EmployeeView��5   	   $	��450��6   $	��800��6+    � DataContext 5	      0   *ManagementApp.ViewModels.EmployeeViewModel  5
   
   .��5      ]� .+�5   
   �� $	��Top=�6   $��Employee Management��6)   $��24(�6D   $
��Bold"�6R   
����ح�
������� �� TextAlignment$ Center=�6�    �� Padding$ 10q�6�   �� 5   
   $��Bottom=�6   $��© 2024 ManagementApp��6,   
����ح�
�������$ Center=�6r   $ 10q�6�   � 5   
    � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   ��6#   �� *	Employees+ �� SelectedItem 6E   �� *SelectedEmployee+��5      �� 5      .R�5      �� $��16(�6:   ��6$   �� *Name+6:   5      5!      �� 5$      $��1��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   .+�5%      �� $	��Add��6   $��10q�6N   
����ح�$	��100��6q   $��50��6}   $��16(�6�   ��6'   �� *AddEmployeeCommand+6�   �� 5&      $
��Edit��6   $��10q�6P   
������$	��100��6t   $��50��6�   $��16(�6�   ��6(   �� *EditEmployeeCommand+6�   �� 5'      $��Delete��6   $��10q�6T   
�������$	��100��6x   $��50��6�   $��16(�6�   ��6*   �� *DeleteEmployeeCommand+6�   5(      �� 5+      $��1��6   $ Vertical=�6&   $��Right=�6=   $��10q�6Y   .+�5,      �� $��Employee ID:��6   $��16(�60   �� 5-      $��0,5,0,10q�6C   $��16(�6U   ��6   �� *
EmployeeId+ �� Mode$ TwoWay=�6U   �� 5/      $��Name:��6   $��16(�6)   �� 50      $��0,5,0,10q�6=   $��16(�6O   ��6   �� *Name+$ TwoWay=�6O   �� 52      $��	Position:��6   $��16(�6-   �� 53      $��0,5,0,10q�6A   $��16(�6S   ��6   �� *
Position+$ TwoWay=�6S   54      55      56      57      