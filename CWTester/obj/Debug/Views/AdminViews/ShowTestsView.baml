   M S B A M L   `   `   `  ����C  ?CWTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CWTester.Views.AdminViewsCWTester.Views.AdminViews  5      -    'CWTester.Views.AdminViews.ShowTestsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      3local'clr-namespace:CWTester.Views.AdminViews  5      .��5
      �   � RowDefinitions  5   
   �� 5      $	��60* �6   �� 5      $	��69* �6   �� 5      $��70 �6   �� 5      $
��265* �6   .+�5   
   � $��0��6   $��2��6   $��	0,0,0,0.4q�6-   .+�5      #  MaterialDesignThemes.Wpf.Card  $��
10,2,10,10q�6"   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth4=�66      UniformCornerRadius$ 5Q�6g   .��5      ��    Welcome#���   6   $��Center=�6=   $��Center=�6Z   $��25(�6u   5      5      � 5   
   $��1��6   5      � 5   
   $��2��6   .+�5        $��10,10,10,10q�6"   $ Depth4=�67   $ 5Q�6h   .��5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5      �� $��1q�6   $��Center=�6N   $��25��6p   $
�� 400��6|   $��Center=�6�   ��62   �� *
searchText+.��6�   5      �� 5      $��75��6   $��25��6(   ��64   �� *
FindByName+.��5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�62   
�������6@   5!      5"      5#      5$      � 5%   
   $��3��6   .+�5&        $��10,10,10,10q�6"   $ Depth4=�67   $ 5Q�6h   .��5'      �� -   5         ��Name$ 	testsList��5'   f   $��244.4��6�   $	��400��6�    �� SelectionMode$ Extended=�6�   ��6   �� *SearchedTests+ �� SelectedItem 6@   �� *SelectedTest+��5(      �� 5)      .R�5*      ��  �� CornerRadius$ 6��6%   $��1q�66   $	��Top=�6J   
������ 	 J� InputBindings	 5+   "   d� 5,   &   &   System.Windows.Input.MouseAction
   	LeftClick d� MouseAction# Z
 63   ._�5.   "   �� $ Vertical=�6-   .+�5/   &     $ 10Q�6:   $	��150��6S   .��50   *   �� $ Vertical=�65   $��75��6L   $	��130��6X   .+�52   .   �� $ 
Horizontal=�69   .+�53   2   �� #��� ��6<   $��	Helvetica)�6Z   �� 54   2    �� Padding$ 10 0 0 0q�6R   $��	Helvetica)�6e   $��WrapWithOverflow=�6|   ��6<   �� *Name+6|   55   /   �� 56   .   $ 
Horizontal=�69   .+�57   2   ��   Description#���  6<   �� 58   2   $ 10 0 0 0q�6Y   $��WrapWithOverflow=�6l   ��6<   �� *Description+6l   59   /   �� 5;   .    
 Delete#���  6�   ��65   ��  �� RelativeSource ��  �� AncestorType$ ListBoxL� �� Path$ DataContext.Delete�6�   �� 5<   .   
���   �68   5=   +   5>   '   5?   #   5@      5A      ��5C      �� 5D       �� 
TargetType" ��6     �� BasedOn# [B��5E       �� Triggers 5F      P� 5G   "    P� Property �@J�IsKeyboardFocusWithin P� Value . . �5H   &   ��  �� Property �@��
IsSelected �� Value . 6C   5I   #   5K      ��5M      �� 5N      .R�5O      � 5P      5R      5S      5T      5U      5V      