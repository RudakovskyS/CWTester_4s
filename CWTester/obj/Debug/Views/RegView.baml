   M S B A M L   `   `   `  ����C  ?CWTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CWTester.ViewsCWTester.Views  5      9!clr-namespace:CWTester.ViewModelsCWTester.ViewModels  69       CWTester.Views.RegView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      (localclr-namespace:CWTester.Views  5      2
viewmodels!clr-namespace:CWTester.ViewModels  69   .��5
      � .+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5        �� EndPoint$  0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ #5203fc��6#   � 5      $ Transparent��6#    � Offset$ 1Q�67   � 5      $ #25ba4f��6#   $
 0.75Q�63   5      5      �� 5   
   $	��280��6   $	��350��6    $��Bottom=�6-   $��35.2,0,35.2,30q�6H    �� RadiusY$ 10��6`    �� RadiusX$ 10��6m   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      	Direction$ 0Q�63   	   RenderingBias$	 Quality=�6A   
   ShadowDepth$
 1Q�6Y      Color$ 	#FFBBBBBB��6i   5      � 5   
   $��Bottom=�6   $��35.2,0,35.2,30q�6*   $	��350��6B   .+�5      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   .+�5      �� $��40��6L   ��6   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 	ArrowBack=���6W   �� *BackCommand+�� 5         Registration#���   6   $��Center=�6A   $	��Top=�6^   $��45,0,0,0q�6v   
�������$��18(�6�   5      �� 5      $��Center=�66   $	��Top=�6S   $��35q�6k   
���  ��$��12(�6�   $
��Wrap=�6�   ��6   �� *ErrorMessage+6�   �� 5      $��Center=�6   $��10q�64   .+�5       �� $	��0,5q�6    	 Login)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6'    % !MaterialDesignFloatingHintTextBox#��[ 6w   $��Champagne & Limousines)�6�   $��14(�6�   ��6`   �� *login+6�   G� 5!      -   5         G�Name$ password_textbox��5!   
  $	��0,5q�6     Password# �  6+    ) %MaterialDesignFloatingHintPasswordBox#��[ 6�   $��Champagne & Limousines)�6�   $��14(�6�   6
  G� 5"      -   5        $" passwordConfirmation_textbox��5"     $	��0,5q�6     ConfirmPassword# �  6+   #��[ 6�   $��Champagne & Limousines)�6�   $��14(�6  6  5#      5$      �� 5%   
   $	��150��6   $��Center=�6<   $��Bottom=�6Y   $
��0,20q�6t     Register#���  6�   ��6   �� *
RegCommand+6�   5&      5'      