   M S B A M L   `   `   `  ����F  BExamenFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ExamenFinal.view.pagesExamenFinal.view.pages  5      &     ExamenFinal.view.pages.AltaLibro   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:ExamenFinal.view.pages     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	        N� Title$  	AltaLibro��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��90 �6   .+�5   
   � -   5         �Name$ ParteInferior��5      $��3��6&    � ColumnDefinitions 5      �� 5      $	��190 �6#   �� 5      $	��450 �6#   �� 5      $	��180 �6#   .+�5      �� -   5         ��Name$ btnAddLibro��5      $��Dar de alta��6*   $��2��6@   $��30 0 0 0q�6M   $	��150��6_   $��40��6k   6w   �� 5      -   5        $��btnModLibro��5      $��1��6(   $��Modificar Libro��68   $	��150��6S   $��40��6_   $��160,25,140,25q�6k   6�   �� 5      -   5        $��btnDelLibro��5      $��2��6(   $��Eliminar Libro��68   $	��150��6R   $��40��6^   6j   5      �� 5   
   $��
Alta libro��6   $
��Left=�6%   $��15 0 0 0q�6@   $��20(�6R   $
��Bold"�6`   � 5!   
   $��1��6    5"      �� 5#      $��* �6    �� 5$      $��50 �6     5'      �� 5(      $��* �6#   �� 5)      $	��300 �6#   .+�5+      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridLibros��5+      $��0��6/   $��10q�6<      AutoGenerateColumns .     
IsReadOnly .    Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6)   
   
Visibility$
 Hidden=�6Q      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	idLibro+6e     5.      $	 Nombre��6)   $	 130 6T    69   �� *titulo+6T     5/      $	 Autor��6)   $	 100 6R    68   �� *autor+6R     50      $	 Año publicación��6)   $	 140 6f    6B   �� *anioPublicacion+6f     51      $	 
ID Género��6)    6<   �� *
idGenero+53      � 55      $��1��6   $��0 0 25 0q�6#    56      �� 57      $��73 �6$   �� 58      $��60 �6$   �� 59      $��60 �6$   �� 5:      $��60 �6$   �� 5;      $��60 �6$   .+�5>      �� $��Datos Libro��6   $
��Bold"�6.   $��34(�6@   �� 5@      $��1��6    �� Orientation$ 
Horizontal=�6*   $��10q�6C   .+�5A      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�6.   $��25��6:   $��25��6E   $��10q�6Q   
���   �6]   �� 5B      -   5         ��Name$ 	txtTitulo��5B      $
��10 0q�61   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre del libro��6?   
���   �$	��250��6�   
���   � �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#FFD944486�   5C      �� 5E      $��2��6   $ 
Horizontal=�6*   $��10q�6C   .+�5F        $ 
Typewriter=�6.   $��25��6@   $��25��6K   $��10q�6W   
���   �6c   �� 5G      -   5        $ txtAutor��5G      $
��10 0q�60   $ Autor��6>   
���   �$	��250��6x   
���   � �	#FFD94448 �	#FFD944486�   5H      �� 5J      $��3��6   $ 
Horizontal=�6*   $��10q�6C   .+�5K        $ CalendarHeart=�6.   $��25��6C   $��25��6N   $��10q�6Z   
���   �6f   �� 5L      -   5        $ txtAnio��5L      $
��10 0q�6/   $ Año de publicación��6=   
���   �$	��250��6�   
���   � �	#FFD94448 �	#FFD944486�   5M      �� 5N      $��4��6   $ 
Horizontal=�6*   $��10q�6C   .+�5O        $ 
Number1Box=�6.   $��25��6@   $��25��6K   $��10q�6W   
���   �6c   �� 5P      -	   5        $ 	txtGenero��5P      $
��10 0q�61   $ ID Género (Número)��6?   
���   �$	��250��6�   
���   � �	#FFD94448 �	#FFD944486�   5Q      5S      5U      �� 5V   
   -
   5        $ 
txtIdLibro��5V      $y�Hidden=�6&   $��1��6:   5W      5X      