   M S B A M L   `   `   `  ����C  ?CWTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CWTester.ViewsCWTester.Views  5   	       CWTester.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CWTester.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  CWTester��5	   	   $	��500��6   $	��800��6'   ���#6f42f5 � Icon$ /Resources/CWTester.ico��6H   .��5
   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $
��274* �6#    � RowDefinitions 5      �� 5      $	��32* �6    �� 5      $
��253* �6    .+�5   
   �� $��1��6   $��Right=�6%    �� Orientation$ 
Horizontal=�6A   .+�5      �� $��0 0 15 0q�6   
������ 
������ $��60��6}   $��60��6�   $��Center=�6�   $��Right=�6�   ��6'   �� *ChangeLanguage+.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WorldWideWeb=�6*   $��25��6>   $��25��6J   5      �� 5      $��1��6   $��0 0 15 0q�6%   
������ 
������ $��60��6�   $��60��6�   $��Center=�6�   $��Right=�6�   ��67   �� *LogOut+.��5        $ 
UserCancel=�6+   $��25��6>   $��25��6J   5      5      � 5   
   $��0��6   $��0��6   .+�5      #  MaterialDesignThemes.Wpf.Card  $��	10 0 10 0q�6"      UniformCornerRadius$ 5Q�65   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth4=�6M   ���#25ba4f.��5      � .+�5      �� $��CWTester��6    $��35(�60   $��	Helvetica)�6>   $��Center=�6U   $��Center=�6p   
���   �6�   �� 5      $��CWTester��6    $��5 5 0 0q�60   $��35(�6A   $��	Helvetica)�6O   $��Center=�6f   $��Center=�6�   
�������6�   5       5!      5"      � 5#   
   $��1��6   $��0��6   .+�5$        $��10q�6"   $ Depth4=�6.   $ 5Q�6_   .��5&      �� $��1��6   ���#25ba4f.+�5'      	� -   5         	�Name$ 
testsRadio��5'   "    	  Tests#���   66   $��20(�6X   $��50��6f     MenuButtonTheme#��[ 6r   ��6�   �� *OpenTestsUC+	� 5(      -   5        $ resultsRadio��5(   "     Results#���  68   $��20(�6\   $��50��6j   #��[ 6v   ��6�   �� *OpenResultsUC+	� 5)      -   5        $ prifileRadio��5)   "     Profile#���  68   $��20(�6\   $��50��6j   #��[ 6v   ��6�   �� *OpenProfileUC+5*      5+      5,       � 5-   
   $��
0 15 10 15q�6   $��1��6%   $��1��62   	  � NavigationUIVisibility$	 Hidden=�6h   ��6B   �� *CurrentUserConrol+6h   5.      5/      