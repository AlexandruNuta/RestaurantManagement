   M S B A M L   `   `   `  ����H  DManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ManagementApp.ViewModelsManagementApp.ViewModels  5   	   #    ManagementApp.Views.TableView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ManagementApp.ViewModels     5   	     � Title$  	TableView��5   	   $	��470��6   $	��796��6(    � DataContext 5
      -  'ManagementApp.ViewModels.TableViewModel  5   
   .��5      ]� .+�5   
   �� $	��Top=�6   $��Table Management��6)   $��24(�6A   $
��Bold"�6O   
����ح�
������� �� TextAlignment$ Center=�6�    �� Padding$ 10q�6�   �� 5   
   $��Bottom=�6   $��© 2024 ManagementApp��6,   
����ح�
�������$ Center=�6r   $ 10q�6�   � 5   
    � RowDefinitions 5      �� 5      $��1* �6    �� 5      $��2* �6     � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      �� ��6   �� *Tables+ �� SelectedItem 65   �� *SelectedTable+��5       �� 5!      .R�5"      �� ��6$   �� *Number+5#      5%      �� 5&      $��2��6\   ��6   �� *Tables+ 65   �� *SelectedTable+��5'      �� 5(      .R�5)      �� ��6$   �� *
WaiterId+5*      5,      �� 5-       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��
0,115,0,10q�6O   $��2��6c   $	��434��6t   .+�5.      �� $	��Add��6   $��10q�6K   
����ح�$��76��6n   $��50��6y   $��16(�6�   ��6'   �� *AddTableCommand+6�   �� 5/      $
��Edit��6   $��10q�6M   
������$��74��6q   $��50��6|   $��16(�6�   ��6(   �� *EditTableCommand+6�   �� 50      $��Delete��6   $��10q�6Q   
�������$��76��6u   $��50��6�   $��16(�6�   ��6*   �� *DeleteTableCommand+6�   �� 51      $
��Link��6   $��10q�6S   
�������$��76��6x   $��50��6�   $��16(�6�   ��6(   �� *LinkWaiterTableCommand+6�   52      �� 54      $��1��6   $ Vertical=�6&   $
��Left=�6=   $��
45,10,0,10q�6X   $��1��6l   .+�55      �� $��	Table ID:��6   �� 56      $��0,5,0,10q�6@   ��6   �� *	TableId+ �� Mode$ TwoWay=�6@   �� 58      $��Number:��6   �� 59      $��0,5,0,10q�6?   ��6   �� *Number+$ TwoWay=�6?   �� 5;      $��Available Seats:��6   �� 5<      $��0,5,0,10q�6G   ��6   �� *AvailableSeats+$ TwoWay=�6G   �� 5>      $��Occupied Seats:��6   �� 5?      $��0,5,0,10q�6F   ��6   �� *OccupiedSeats+$ TwoWay=�6F   �� 5A      $��
Waiter ID:��6   �� 5B      $��0,5,0,10q�6A   ��6   �� *
WaiterId+$ TwoWay=�6A   5C      5D      5E      5F      