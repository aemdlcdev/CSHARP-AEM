   M S B A M L   `   `   `  ����F  BExamenFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ExamenFinal.view.pagesExamenFinal.view.pages  5      &     ExamenFinal.view.pages.AltaSocio   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:ExamenFinal.view.pages     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        N� Title$  	AltaSocio��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��90 �6   .+�5   
   � -   5         �Name$ ParteInferior��5      $��3��6&    � ColumnDefinitions 5      �� 5      $	��190 �6#   �� 5      $	��450 �6#   �� 5      $	��180 �6#   .+�5      �� -   5         ��Name$ btnAddSocio��5      $��Dar de alta��6*   $��2��6@   $��30 0 0 0q�6M   $	��150��6_   $��40��6k   6w   �� 5      -   5        $��btnModSocio��5      $��1��6(   $��Modificar socio��68   $	��150��6S   $��40��6_   $��160,25,140,25q�6k   6�   �� 5      -   5        $��btnDelSocio��5      $��2��6(   $��Eliminar socio��68   $	��150��6R   $��40��6^   6j   5      �� 5   
   $��
Alta socio��6   $
��Left=�6%   $��15 0 0 0q�6@   $��20(�6R   $
��Bold"�6`   � 5!   
   $��1��6    5"      �� 5#      $��* �6    �� 5$      $��50 �6     5'      �� 5(      $��* �6#   �� 5)      $	��300 �6#   .+�5,      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridSocios��5,      $��0��6/   $��10q�6<      AutoGenerateColumns .     
IsReadOnly .    Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6)   
   
Visibility$
 Hidden=�6Q      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	idSocio+6e     5/      $	 Nombre Socio��6)   $	 150 6_    6?   �� *nombreSocio+6_     50      $	 Fec Nacimiento��6)   $	 150 6d    6A   �� *fec_nacimiento+6d     51      $	 Email��6)    68   �� *email+  52      $	 Telefono��6)    6;   �� *tlfno+54      � 56      $��1��6   $��0 0 25 0q�6#    57      �� 58      $��73 �6$   �� 59      $��60 �6$   �� 5:      $��60 �6$   �� 5;      $��60 �6$   �� 5<      $��60 �6$   .+�5?      �� $��Datos Socio��6   $
��Bold"�6.   $��34(�6@   �� 5A      $��1��6    �� Orientation$ 
Horizontal=�6*   $��10q�6C   .+�5B      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�6.   $��25��6:   $��25��6E   $��10q�6Q   
���   �6]   �� 5C      -   5         ��Name$ 	txtNombre��5C      $
��10 0q�61   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre del socio��6?   
���   �$	��250��6�   
���   � �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#FFD944486�   5D      �� 5F      $��2��6   $ 
Horizontal=�6*   $��10q�6C   .+�5G        $ 	DateRange=�6.   $��25��6?   $��25��6J   $��10q�6V   
���   �6b   �� 5H      -   5        $ 	txtFecnac��5H      $
��10 0q�61   $&  Fecha de nacimiento (DD/MM/YYYY)��6?   
���   �$	��250��6�   
���   � �	#FFD94448 �	#FFD944486�   5I      �� 5K      $��3��6   $ 
Horizontal=�6*   $��10q�6C   .+�5L        $ Email=�6.   $��25��6;   $��25��6F   $��10q�6R   
���   �6^   �� 5M      -   5        $ txtEmail��5M      $
��10 0q�60   $ Email del socio��6>   
���   �$	��250��6�   
���   � �	#FFD94448 �	#FFD944486�   5N      �� 5O      $��4��6   $ 
Horizontal=�6*   $��10q�6C   .+�5P        $ Phone=�6.   $��25��6;   $��25��6F   $��10q�6R   
���   �6^   �� 5Q      -	   5        $ txtTlfn��5Q      $
��10 0q�6/   $ Telefono del socio��6=   
���   �$	��250��6�   
���   � �	#FFD94448 �	#FFD944486�   5R      5T      5V      �� 5W   
   -
   5        $ 
txtIdSocio��5W      $y�Hidden=�6&   $��1��6:   5X      5Y      