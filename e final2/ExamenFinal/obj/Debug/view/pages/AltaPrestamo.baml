   M S B A M L   `   `   `  ����F  BExamenFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ExamenFinal.view.pagesExamenFinal.view.pages  5      )    #ExamenFinal.view.pages.AltaPrestamo   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:ExamenFinal.view.pages     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        N� Title$  AltaPrestamo��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��90 �6   .+�5   
   � -   5         �Name$ ParteInferior��5      $��3��6&    � ColumnDefinitions 5      �� 5      $	��190 �6#   �� 5      $	��450 �6#   �� 5      $	��180 �6#   .+�5      �� -   5         ��Name$ btnAddLibro��5      $��Dar de alta��6*   $��20,25,10,25q�6@   $	��160��6U   $��40��6a   �� 5      -   5        $��btnModLibro��5      $��1��6(   $��Modificar Prestamo��68   $	��160��6V   $��40��6b   $��160,25,140,25q�6n   �� 5      -   5        $��btnDelLibro��5      $��2��6(   $��Eliminar Prestamo��68   $	��160��6U   $��40��6a   5      �� 5   
   $��Gestionar Prestamos��6   $
��Left=�6.   $��15 0 0 0q�6I   $��20(�6[   $
��Bold"�6i   � 5!   
   $��1��6    5"      �� 5#      $��* �6    �� 5$      $��50 �6     5'      �� 5(      $��* �6#   �� 5)      $	��300 �6#   .+�5+      �� -   5         ��Name$ 
txtIdEmple��5+      $y�Hidden=�6*   �� 5,      -   5        $ txtIdUsuEmple��5,      $y�Hidden=�6-   &   System.Windows.Controls.DataGrid  5-      -   5          Name$ dataGridEmpleados��5-      $��0��62   $��10q�6?      AutoGenerateColumns .     
IsReadOnly . 	   Columns	 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6)      
Visibility$ Hidden=�6Q      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	idLibro+6e     50      $
 Nombre��6)   $	 100 6T    69   �� *titulo+6T     51      $
 Autor��6)   $	 100 6R    68   �� *autor+6R     52      $
 Año publicación��6)   $	 140 6f    6B   �� *anioPublicacion+6f     53      $
 
ID Género��6)    6<   �� *
idGenero+55      � 57      $��1��6   $��0 0 25 0q�6#    58      �� 59      $��73 �6$   �� 5:      $��60 �6$   �� 5;      $��60 �6$   �� 5<      $��60 �6$   �� 5=      $��60 �6$   .+�5@      �� $��Datos Prestamo��6   $
��Bold"�61   $��34(�6C   �� 5B      $��1��6    �� Orientation$ 
Horizontal=�6*   $��10q�6C   .+�5C      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�6.   $��25��6:   $��25��6E   $��10q�6Q   
���   �6]   �� 5D      -   5        $ 
txtIdSocio��5D      $
��10 0q�62   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ID Socio��6@   
���   �$	��250��6}   
���   � �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#FFD944486�   5E      �� 5G      $��2��6   $ 
Horizontal=�6*   $��10q�6C   .+�5H        $ BookAdd=�6.   $��25��6=   $��25��6H   $��10q�6T   
���   �6`   �� 5I      -	   5        $ 
txtIdLibro��5I      $
��10 0q�62   $ ID Libro��6@   
���   �$	��250��6}   
���   � �	#FFD94448 �	#FFD944486�   5J      �� 5L      $��3��6   $ 
Horizontal=�6*   $��10q�6C   .+�5M        $ CalendarHeart=�6.   $��25��6C   $��25��6N   $��10q�6Z   
���   �6f   �� 5N      -
   5        $ 
txtFInicio��5N      $
��10 0q�62   $ Fecha inicio��6@   
���   �$	��250��6�   
���   � �	#FFD94448 �	#FFD944486�   5O      �� 5P      $��4��6   $ 
Horizontal=�6*   $��10q�6C   .+�5Q        $ CalendarEnd=�6.   $��25��6A   $��25��6L   $��10q�6X   
���   �6d   �� 5R      -   5        $ txtFFin��5R      $
��10 0q�6/   $ 	Fecha fin��6=   
���   �$	��250��6{   
���   � �	#FFD94448 �	#FFD944486�   5S      5U      5W      �� 5X   
   -   5        $ 
txtIdUserr��5X      $y�Hidden=�6&   $��1��6:   5Y      5Z      