   M S B A M L   `   `   `  ����?  ;Taxi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Taxi.View.Pages.operatorvTaxi.View.Pages.operatorv  5      '    !Taxi.View.Pages.operatorv.Tickets   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Taxi.View.Pages.operatorv     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  tickets��5
      .��5      ]� .+�5   
   �� .��5   
   �� .+�5      �� $��Center=�6   $��Center=�65   $��20(�6P   $
��Bold"�6^   .��6p   Тикеты6x   �� 5      -   5         ��Name$
 sort��5      ��5      �� 5      .R�5      ��  d� 	IsChecked 6#   �� *Check+��6?   �� *Status.name+5      5      �� 5      -   5        .��5   (   
Найти6/   5      5      �� 5   
   -   5        $ 
ticketList��5      $��1��6   ��5      �� 5      .R�5      �  K� IsItemsHost . 65   5      ��5!      �� 5"      .R�5#      #  MaterialDesignThemes.Wpf.Card  $	��150��6*   .��5$      �� .+�5%      �� ��6$   �� *	Car.photo+�� 5&       �� Orientation$ 
Horizontal=�6)   .+�5'   "   �� $
��Wrap=�6,   $��Из: ��6@   6N   �� 5(   "   $
��Wrap=�6,   ��6@   �� *Ticket. startStreet+6g   �� 5*   "   $
��Wrap=�6,   ��6@   �� *Ticket. startHouse+6f   5+      �� 5,      $ 
Horizontal=�6)   .+�5-   "   �� $
��Wrap=�6,   $
��в: ��6@   6M   �� 5.   "   $
��Wrap=�6,   ��6@   �� *Ticket. endStreet+6e   �� 5/   "   $
��Wrap=�6,   ��6@   �� *Ticket. endHouse+6d   50      �� 51      $ 
Horizontal=�6)   .+�52   "   �� $��Статус: ��6,   �� 53   "   ��6,   �� *Ticket.status1.name+54      55      56      57      59      5:      5;      