   M S B A M L   `   `   `  ����H  DManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ManagementApp.ViewModelsManagementApp.ViewModels  5   	   #    ManagementApp.Views.OrderPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ManagementApp.ViewModels     5   	     � Title$  	OrderPage��5   	   $	��748��6   $
��1074��6(    � DataContext 5	      -   'ManagementApp.ViewModels.OrderViewModel  5
   
   .��5      ]� .+�5   
   �� $	��Top=�6   $��Order Management��6)   $��24(�6A   $
��Bold"�6O   
����ح�
������� �� TextAlignment$ Center=�6�    �� Padding$ 10q�6�   �� 5   
   $��Bottom=�6   $��© 2024 ManagementApp��6,   
����ح�
�������$ Center=�6r   $ 10q�6�   � 5   
    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��* �6#   .+�5      � $��0��6    � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   .+�5"      �� $��0��6   ��6'   �� *Orders+ �� SelectedItem 6F   �� *SelectedOrder+��5#      �� 5$      .R�5%      �� $��16(�6<   ��6(   �� *Id+6<   5&      5(      52      �� 55      $��1��6    �� Orientation$ Vertical=�6)   $��10q�6@   .+�56      �� $��Create Order:��6   $��18(�61   $
��Bold"�6?   �� 57      $��OrderId:��6   �� 58      $��0,5,0,10q�66   $��16(�6H   ��6   �� *
NewOrderId+6H   �� 59      $��Total Amount:��6   �� 5:      $��0,5,0,10q�6?   $��16(�6Q   ��6   �� *NewOrderTotalAmount+6Q   �� 5;      $��Order Date:��6   (  "System.Windows.Controls.DatePicker  5<      $��0,5,0,10q�6C      SelectedDate 6   �� *NewOrderDate+6C   �� 5=      $��Status:��6   �� 5>      $��0,5,0,10q�6:   $��16(�6L   ��6   �� *NewOrderStatus+6L   �� 5?      $��	Table ID:��6   �� 5@      $��0,5,0,10q�6;   $��16(�6M   ��6   �� *NewOrderTableId+6M   �� 5A      $��Create Order��6   $��0,10,0,0q�6W   
����ح�$	��150��6�   $��50��6�   $��16(�6�   ��60   �� *CreateOrderCommand+6�   �� 5B      $��Generate Ticket��6   $��0,10,0,0q�6]   
����ح�$	��150��6�   $��50��6�   $��16(�6�   ��63   �� *GenerateTicketCommand+6�   �� 5C      $��Add Product to Order:��6   $��18(�69   $
��Bold"�6G   �� 5D      	 �� DisplayMemberPath$
	 Name��6n   ��6   �� *AvailableProducts+ 6E   �� *SelectedProduct+6n   �� 5E      $��	Quantity:��6   �� 5F      $��0,5,0,10q�6C   $��16(�6U   ��6   �� *SelectedProductQuantity+6U   �� 5G      $��TotalPrice:��6   �� 5H      $��16(�6?   ��6   �� *IntermediateTotal+6?   �� 5I      $��Add Product to Order��6   
������$��96��6}   $��36��6�   $��16(�6�   ��68   �� *AddProductToOrderCommand+6�   �� 5J      $��Delete Order��6   
�������$��96��6o   $��36��6z   $��16(�6�   ��60   �� *DeleteOrderCommand+6�   5K      5L      5M      5N      