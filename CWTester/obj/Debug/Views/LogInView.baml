   M S B A M L   `   `   `  ����C  ?CWTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CWTester.ViewsCWTester.Views  5          CWTester.Views.LogInView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      (localclr-namespace:CWTester.Views  5      .��5
      � .+�5   
   � $
��Left=�6   $	��350��6*   .+�5      �� $	��350��6   $	��Top=�6%   ��5      �� 5        �� EndPoint$  0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ #5203fc��6'   � 5      $ Transparent��6'    � Offset$ 1Q�6;   � 5      $ #25ba4f��6'   $
 0.75Q�67   5      5      �� 5      $	��280��6   $	��260��6$   $��Bottom=�61   $
��0,80q�6L    �� RadiusY$ 10��6Z    �� RadiusX$ 10��6g   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6'      	Direction$ 0Q�67   	   RenderingBias$	 Quality=�6E   
   ShadowDepth$
 1Q�6]      Color$ 	#FFBBBBBB��6m   5      '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$
 User=�6&   $	��100��62   $	��100��6>   $	��Top=�6K   $��
125,30,0,0q�6c   � 5      $��Bottom=�6   $��35,80q�6.   $	��260��6=   .+�5      ��  	  Login#���   6   $��Center=�6:   $	��Top=�6W   $��5q�6o   
�������$��18(�6�   $��	Helvetica)�6�   �� 5      $��Center=�6:   $	��Top=�6W    �� TextAlignment$ Center=�6o   $��30q�6�   
���  ��$��12(�6�   $��	Helvetica)�6�   $	��280��6�   $
��Wrap=�6�   ��6   �� *ErrorMessage+6�   �� 5      $��Center=�6   $��
15,40,15,0q�68   .+�5      �� $
��0,10q�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   6,    % !MaterialDesignFloatingHintTextBox#��[ 6|   $��Champagne & Limousines)�6�   $��18(�6�   ��6e   �� *login+6�   G� 5       -   5         G�Name$ password_textbox��5      $
��0,10q�6"     Password# �  60    ) %MaterialDesignFloatingHintPasswordBox#��[ 6�   $��Champagne & Limousines)�6�   $��18(�6  6  5!      5"      �� 5#      $	��150��6   $��Center=�6A   $��Bottom=�6^   $
��0,65q�6y   #���   6�   ��6!   �� *AuthCommand+6�   �� 5$      $	��150��6   $��Center=�6D   $��Bottom=�6a   $
��0,33q�6|     Register#���  6�   ��6!   �� *OpenRegCommand+6�   5%      5&      5'      