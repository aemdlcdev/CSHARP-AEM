   M S B A M L   `   `   `  ���� F  BExamenFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ExamenFinal.view.pagesExamenFinal.view.pages  &     ExamenFinal.view.pages.AltaSocio   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:ExamenFinal.view.pages     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     N� Title$  	AltaSocio��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $��90 �.+�� -    �Name$ ParteInferior��$��3�� � ColumnDefinitions �� $	��190 ��� $	��450 ��� $	��180 �.+��� -    ��Name$ btnAddSocio��$��Dar de alta��$��2��$��30 0 0 0q�$	��150��$��40���� -   $��btnModSocio��$��1��$��Modificar socio��$	��150��$��40��$��160,25,140,25q��� -   $��btnDelSocio��$��2��$��Eliminar socio��$	��150��$��40���� $��
Alta socio��$
��Left=�$��15 0 0 0q�$��20(�$
��Bold"�� $��1�� �� $��* ��� $��50 � �� $��* ��� $	��300 �.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGridSocios��$��0��$��10q�   AutoGenerateColumns .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��
   
Visibility$
 Hidden=�   Width5  /System.Windows.Controls.DataGridLengthConverter$ 2 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	idSocio+  $	 Nombre Socio��$	 150  �� *nombreSocio+  $	 Fec Nacimiento��$	 150  �� *fec_nacimiento+  $	 Email�� �� *email+  $	 Telefono�� �� *tlfno+� $��1��$��0 0 25 0q� �� $��73 ��� $��60 ��� $��60 ��� $��60 ��� $��60 �.+��� $��Datos Socio��$
��Bold"�$��34(��� $��1�� �� Orientation$ 
Horizontal=�$��10q�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�$��25��$��25��$��10q�
���   ��� -    ��Name$ 	txtNombre��$
��10 0q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre del socio��
���   �$	��250��
���   � �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#FFD94448�� $��2��$ 
Horizontal=�$��10q�.+�  $ 	DateRange=�$��25��$��25��$��10q�
���   ��� -   $ 	txtFecnac��$
��10 0q�$&  Fecha de nacimiento (DD/MM/YYYY)��
���   �$	��250��
���   � �	#FFD94448 �	#FFD94448�� $��3��$ 
Horizontal=�$��10q�.+�  $ Email=�$��25��$��25��$��10q�
���   ��� -   $ txtEmail��$
��10 0q�$ Email del socio��
���   �$	��250��
���   � �	#FFD94448 �	#FFD94448�� $��4��$ 
Horizontal=�$��10q�.+�  $ Phone=�$��25��$��25��$��10q�
���   ��� -	   $ txtTlfn��$
��10 0q�$ Telefono del socio��
���   �$	��250��
���   � �	#FFD94448 �	#FFD94448�� -
   $ 
txtIdSocio��$y�Hidden=�$��1��