   M S B A M L   `   `   `  ���� Z  VMultiScreener Media, Version=1.0.3.0, Culture=neutral, PublicKeyToken=aa62a66efb9b0a34O,clr-namespace:MultiScreener_Media.PropertiesMultiScreener_Media.Properties  9!clr-namespace:MultiScreener_MediaMultiScreener_Media  $    MultiScreener_Media.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;my,clr-namespace:MultiScreener_Media.Properties     3local!clr-namespace:MultiScreener_Media     -     �Name$  
mainWindow�� � Title$ Multi-Screener Media��$	��525��$	��685�� � Icon$ Resources/1440792.ico�� � 
ResizeMode$ NoResize=� � 	Resources    Chubs_SliderStyle �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard g� Duration	 W� To �� TargetProperty �� 
TargetName R� KeyTime R� Value �Name ��Name J� IsHitTestVisible J� Clip �� Rect  ItemcontainerStyle ��Name J� SnapsToDevicePixels � ColumnDefinitions z� SharedSizeGroup ��Name m� Icon 	�Name m� 	IsChecked d� 	IsChecked  	� 	GroupName! �� HeaderStringFormat" �� ContentStringFormat# ��Name$ J� Opacity% m� InputGestureText& �� Triggers' P� Value( P� Property) �� 
TargetName* P� 
SourceName+ ]� 
Conditions, �� Property- �� Value  SliderRepeatButton. �� CornerRadius  SliderRepeatButton1  SliderThumb 
 Slider/ � RowDefinitions0 ]�Name1 ]� DecreaseRepeatButton2 ]� Thumb3 ]� IncreaseRepeatButton  Horizontal_Slider4 �� Triggers��%_  &	        &	 �    &	 7	    &	 
    &	 �
    &	 X    7  7  7  &	 &    7  �� " ��.���  � ��$ 0q���  � ��
 ���� ��  �@�Maximum$ 10Q���  �@�Minimum$ 0Q���  �@�Value$ 0Q���  � �� �#c8c8c8��  � �� �#287dcc��  � �� �� " ��.R�� 
������ 	   CommonStates��.
   
Normal��  	MouseOver��  Disabled��. �� .��W� $ 0D�$	 0.1X�$ Opacity�$ HorizontalTrack��W� $ 0D�$	 0.1X�$ Opacity�$ VerticalTrack��T� $
 Fill�$ HorizontalFill��..�i� $ 0��$ Black��T� $
 Fill�$ VerticalFill��..�i� $ 0��$ Black��.+�� $ HorizontalTemplate��$��0,0,0,0q�.+��� $ HorizontalTrack�����#c8c8c8$��4�� .  $��	0,22,0,50q��� $ HorizontalFill�����	#FFABABAB$��4�� .  $��	0,22,0,50q� �� $ 0, 0, 6, 12��� $ HorizontalCenterElement��#��� ��$
��Left=�$��12��$��	0,16,0,44q�$��8��z�T� �� " m�.���  � �� �� " m�.R��� $ templateRoot��#��z��#��z��#��z�� . ._�� $��-1q� �� $��22��$ MenuItemIconColumnGroup��$
��Auto ��� $��13 ��� $��* ��� $��30 ��� $ MenuItemIGTColumnGroup��$
��Auto ��� $��20 �.+��� $
 Icon��#��z $
��Icon��$��Center=�$��16��$��3q�# z $��Center=�$��16���� $ 
GlyphPanel�����	#FF26A0DA$��1q����	#3D26A0DA}�.  $��Center=�$��22��$��-1,0,0,0q�$y�Hidden=�$��Center=�$��22��._�	� $ Glyph��# z $  a��$��Center=�$��Center=��� $ menuHeaderContainer��#��z��#��z��$��2��#" z! $��Header��$
��Left=�#��z����. # z $��Center=��� $# menuGestureText��$��4��#��z��$	$ 0.7Q�#��z% $��Center=�& P� ' Z� ( �@m�Icon. ��� $
) Icon�� � y�$ 	Collapsed=�P� ( �@m�	IsChecked' . . ��� $) 
GlyphPanel�� � y�$ Visible=��� $
) Icon�� � y�$ 	Collapsed=�P� $* Glyph��( �@d�	IsChecked$' FalseY�. ��� $) 
GlyphPanel�� � y�$ Hidden=��� $) Glyph�� � y�$ 	Collapsed=�P� ( �@m�IsHighlighted' . . ��� $) templateRoot�� � �� �	#3D26A0DA�� $) templateRoot�� � �� �	#FF26A0DAP� ( � {�' .  . ��� $) templateRoot�� � �� �	#FF707070]� + �� , �@m�IsHighlighted- . �� , � {�- .  ./��� $) templateRoot�� � �� �	#0A000000�� $) templateRoot�� � �� �	#21000000�� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� $��1q�
���   ����	#FFD9D9D9$��6��$. 1,1,1,1���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� " ��.R���  . ���	#FF287DCC$��1q�
���   �$��6��$. 1,1,1,1���� " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� " n��� " ��.R�� / �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�]� $0 
PART_Track��$��1��1 �� 8��  $��Slider.DecreaseLarge��2 n� 8�� 3 �� 8�� $��Slider.IncreaseLarge���� " ��.���  � |� .  ��  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . 4 P� ( �@��Orientation$' 
Horizontal=�. ���  � ��$ 21����  � ��$	 104����  � ��8   .��� .+��� -   5 ��Name$5 contentsListBox��$	��320��$��
10,30,10,0q�$	��Top=�$��18(�$��Italic$�6 J� 	AllowDrop6 . ���� .R��� 7 �� Orientation$7 
Horizontal=�.+��� $��3q����� *Path+�� $��3q����� *Name+o� -   8 o�Name$8 fileMenu��$��20��$��0q�$	��Top=�$��14(�.@�m� $
��File��.@�m� -   9 m�Name$9 openFolderMenuItem��$��Open Folder...��m� -   $9 openFilesMenuItem��$��Open Files...��m� -   $9 clearFilesMenuItem��$��Clear File Viewer��m� -   $9 viewMenu��$
��View��#��[ .@�m� -   $"9 catergoriseFileExtensionItem��: m� IsCheckable: . $��Name with File Extension��m� -	   $9 categoriseNameItem��: . $
��Name��m� -
   $9 categoriseFilenameItem��: . $��Filename��m� $��Media��.@�m� -   $��
Jump at...��m� -   $��Open previewer��m� -   $��About���� 
���   �$��1q�$	��128��$��	10,0,10,2q�$��Bottom=�$. 5��._�� .+��� -   ; ��Name$; 
playButton��$�� ��$��64��$��64��$
��Left=�$��8,0,0,12q�$��Bottom=���Z� ���� < �� ImageSource$< Resources/play.png������ " ��.���  �@�OverridesDefaultStyle . ��  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ border��$��0q����	#FF3A3939#��z��._��� $��Center=�$��Center=�& P� ( �@J�IsMouseOver' . . ���  �@J�Opacity$	 0.7Q��� -   $; 
stopButton��$�� ��$��64��$��64��$
��Left=�$��	80,0,0,10q�$��Bottom=���Z� ���� $< Resources/stop.png������ " ��.���  �@�OverridesDefaultStyle . ��  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ border��$��0q����	#FF3A3939#��z��._��� $��Center=�$��Center=�& P� ( �@J�IsMouseOver' . . ���  �@J�Opacity$	 0.7Q��� -   $; toggleMuteButton��$�� ��$��64��$��64��$��Right=�$��	0,0,262,5q�$��Bottom=���Z� ���� $< Resources/audio.png������ " ��.���  �@�OverridesDefaultStyle . ��  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ border��$��0q����	#FF3A3939#��z��._��� $��Center=�$��Center=�& P� ( �@J�IsMouseOver' . . ���  �@J�Opacity$	 0.7Q��� -   $; restartButton��$�� ��$��64��$��64��$
��Left=�$��
160,0,0,10q�$��Bottom=���Z� ���� $< Resources/restartIcon.png������ " ��.���  �@�OverridesDefaultStyle . ��  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ border��$��0q����	#FF3A3939#��z��._��� $��Center=�$��Center=�& P� ( �@J�IsMouseOver' . . ���  �@J�Opacity$	 0.7Q��� -   = ��Name$= masterVolumeSlider��$��Right=�$��Bottom=�$	��245��> � Maximum$	> 100Q�? � SmallChange$? 1Q�@ � LargeChange$@ 5Q�A � Value$	A 100Q�$��50�����	#FF22EC41$��	0,0,12,12q� B � 	Resources  KeyC �� EdgeModeD �� BitmapScalingModeE J� OpacityMaskF L� DrawingG � Brush  TriangleH � GeometryI �� DelayJ �� Stretch��%�  '��       7  7  �� " ��.���  � ��
 �������  � ��$ 20����  � �� �� " ��B ���� '��       " ��.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� #��z��B� Triangle $C Aliased=�$
D Fant=�$��M0,1 L1,1 L1,0 L0,1C�.R�� .+�� E L� F � 
G �   �$C Aliased=�$
D Fant=�8H   .+�]� $0 
PART_Track��#��zA 2 n� $��10��#��z������ " n�.R��� #��z��1 �� #��z��$��Slider.DecreaseLarge��$	I 140��3 �� 
������ $��Slider.IncreaseLarge��$	I 140��F� 8�� $
J Fill=�
���   �$��1���� -   $= timeBar��#���  $��	16,8,16,0q�$	��Top=�$	> 100Q�K �� IsMoveToPointEnabledK . {�.  �� -   L ��Name$L maxDurationLabel��$��00:00��$��Right=�$��	0,18,10,0q�$	��Top=�M J� RenderTransformOrigin$M -0.543,0.675&�$��16(�$��Normal"��� -   $L currentTimeLabel��$��00:00��$
��Left=�$��	10,17,0,0q�$	��Top=�$M -0.543,0.675&�$��16(�$��Normal"�$��Normal$��� -   $L volumeLabel��$
��100%��$��Right=�$��
0,0,157,28q�$��Bottom=�$��16(�$��Normal$�$��Normal"����	#FF5D5D5D