   M S B A M L   `   `   `  ���� F  BExamenFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ExamenFinal.view.pagesExamenFinal.view.pages  )    #ExamenFinal.view.pages.AltaPrestamo   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:ExamenFinal.view.pages     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     N� Title$  AltaPrestamo��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $��90 �.+�� -    �Name$ ParteInferior��$��3�� � ColumnDefinitions �� $	��190 ��� $	��450 ��� $	��180 �.+��� -    ��Name$ btnAddLibro��$��Dar de alta��$��20,25,10,25q�$	��160��$��40���� -   $��btnModLibro��$��1��$��Modificar Prestamo��$	��160��$��40��$��160,25,140,25q��� -   $��btnDelLibro��$��2��$��Eliminar Prestamo��$	��160��$��40���� $��Gestionar Prestamos��$
��Left=�$��15 0 0 0q�$��20(�$
��Bold"�� $��1�� �� $��* ��� $��50 � �� $��* ��� $	��300 �.+��� -    ��Name$ 
txtIdEmple��$y�Hidden=��� -   $ txtIdUsuEmple��$y�Hidden=�&   System.Windows.Controls.DataGrid  -     Name$ dataGridEmpleados��$��0��$��10q�   AutoGenerateColumns .     
IsReadOnly . 	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��   
Visibility$ Hidden=�   Width5  /System.Windows.Controls.DataGridLengthConverter$ 2 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	idLibro+  $
 Nombre��$	 100  �� *titulo+  $
 Autor��$	 100  �� *autor+  $
 Año publicación��$	 140  �� *anioPublicacion+  $
 
ID Género�� �� *
idGenero+� $��1��$��0 0 25 0q� �� $��73 ��� $��60 ��� $��60 ��� $��60 ��� $��60 �.+��� $��Datos Prestamo��$
��Bold"�$��34(��� $��1�� �� Orientation$ 
Horizontal=�$��10q�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�$��25��$��25��$��10q�
���   ��� -   $ 
txtIdSocio��$
��10 0q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ID Socio��
���   �$	��250��
���   � �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#FFD94448�� $��2��$ 
Horizontal=�$��10q�.+�  $ BookAdd=�$��25��$��25��$��10q�
���   ��� -	   $ 
txtIdLibro��$
��10 0q�$ ID Libro��
���   �$	��250��
���   � �	#FFD94448 �	#FFD94448�� $��3��$ 
Horizontal=�$��10q�.+�  $ CalendarHeart=�$��25��$��25��$��10q�
���   ��� -
   $ 
txtFInicio��$
��10 0q�$ Fecha inicio��
���   �$	��250��
���   � �	#FFD94448 �	#FFD94448�� $��4��$ 
Horizontal=�$��10q�.+�  $ CalendarEnd=�$��25��$��25��$��10q�
���   ��� -   $ txtFFin��$
��10 0q�$ 	Fecha fin��
���   �$	��250��
���   � �	#FFD94448 �	#FFD94448�� -   $ 
txtIdUserr��$y�Hidden=�$��1��