   M S B A M L   `   `   `  ����H  DManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ManagementApp.ViewModelsManagementApp.ViewModels  5   	   %    ManagementApp.Views.ProductView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ManagementApp.ViewModels     5   	     � Title$  ProductView��5   	   $	��450��6   $	��800��6*    � DataContext 5	      /   )ManagementApp.ViewModels.ProductViewModel  5
   
   .��5      ]� .+�5   
   �� $	��Top=�6   $��Product Management��6)   $��24(�6C   $
��Bold"�6Q   
����ح�
������� �� TextAlignment$ Center=�6�    �� Padding$ 10q�6�   �� 5   
   $��Bottom=�6   $��© 2024 ManagementApp��6,   
����ح�
�������$ Center=�6r   $ 10q�6�   � 5   
    � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   ��6#   �� *
Products+ �� SelectedItem 6D   �� *SelectedProduct+��5      �� 5      .R�5       �� $��16(�6:   ��6$   �� *Name+6:   5!      5#      �� 5&       �� Orientation$ 
Horizontal=�6   $
��Left=�62   $��
80,147,0,0q�6M   $��2��6a   .+�5'      �� $	��Add��6   $��10q�6M   
����ح�$	��100��6p   $��50��6|   $��16(�6�   ��6'   �� *AddProductCommand+6�   �� 5(      $
��Edit��6   $��10q�6O   
������$	��100��6s   $��50��6   $��16(�6�   ��6(   �� *EditProductCommand+6�   �� 5)      $��Delete��6   $��10q�6S   
�������$	��100��6w   $��50��6�   $��16(�6�   ��6*   �� *DeleteProductCommand+6�   5*      �� 5-      $��1��6   $ Vertical=�6&   $��Right=�6=   $��10q�6Y   .+�5.      �� $��Product ID:��6   $��16(�6/   �� 5/      $��0,5,0,10q�6B   $��16(�6T   ��6   �� *	ProductId+ �� Mode$ TwoWay=�6T   �� 51      $��Name:��6   $��16(�6)   �� 52      $��0,5,0,10q�6D   $��16(�6V   ��6   �� *ProductName+$ TwoWay=�6V   �� 54      $��Price:��6   $��16(�6*   �� 55      $��0,5,0,10q�6>   $��16(�6P   ��6   �� *Price+$ TwoWay=�6P   58      59      5:      5;      