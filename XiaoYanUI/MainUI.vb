'引入Drawing2D，提供高质量绘图
Imports System.Drawing.Drawing2D

Public Class MainUI
    '界面的动态效果使用单独线程支持
    Dim Thread雪豹 As Threading.Thread
    Dim Thread时间 As Threading.Thread
    Dim Thread进度 As Threading.Thread
    Dim Thread背景 As Threading.Thread
    Dim Thread箭头 As Threading.Thread
    '动态箭头高亮显示使用的变量
    Dim HighLightArrows As Boolean = False
    '壁纸标识
    Dim WallpaperIndex As Integer = 1

    '在窗体上绘制Visual Studio的Logo
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim MyGraphics As Graphics = e.Graphics
        MyGraphics.SmoothingMode = SmoothingMode.HighQuality
        MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality

        Dim MyBitmap As New Bitmap(My.Resources.UIResource.VSlogo)
        MyGraphics.DrawImage(MyBitmap, 1, 1, MyBitmap.Width, MyBitmap.Height)
        GC.Collect()
    End Sub

    Private Sub MainUI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        '窗体关闭，卸载全部线程
        Thread时间.Abort()
        Thread时间 = Nothing
        Thread雪豹.Abort()
        Thread雪豹 = Nothing
        Thread箭头.Abort()
        Thread箭头 = Nothing
        If Not (Thread进度 Is Nothing) Then
            Thread进度.Abort()
            Thread进度 = Nothing
        End If
        If Not (Thread背景 Is Nothing) Then
            Thread背景.Abort()
            Thread背景 = Nothing
        End If

        End
    End Sub

    Private Sub MainUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '双缓冲绘图，防止闪烁
        Me.DoubleBuffered = True

        '窗体启动，启动部分线程
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False '允许多线访问UI

        Thread雪豹 = New Threading.Thread(AddressOf Dynamic雪豹)
        Thread雪豹.Start()
        Thread时间 = New Threading.Thread(AddressOf ShowTime)
        Thread时间.Start()
        Thread箭头 = New Threading.Thread(AddressOf DynamicArrows)
        Thread箭头.Start()

        '使用Lable控件做按钮，免去自己开发用户控件的步骤，一条捷径。
        '初始化窗体的关闭按钮和功能按钮图像（Type:Label）
        Dim BitmapRectangle As New Rectangle(0, 0, 27, 27)
        lblCloseButton.Image = My.Resources.UIResource.关闭窗口.Clone(BitmapRectangle, Imaging.PixelFormat.Format32bppArgb)
        BitmapRectangle = New Rectangle(0, 0, 136, 53)
        btn_加载.Image = My.Resources.UIResource.按钮.Clone(BitmapRectangle, Imaging.PixelFormat.Format32bppArgb)
    End Sub

    '线程“Thread箭头”绑定的Sub过程，显示窗体下方的动态箭头
    Private Sub DynamicArrows()
        Dim PicIndex As Integer = 0
        Do While True '无限循环
            PicIndex = IIf(PicIndex = 23, 0, PicIndex + 1)
            Dim BitmapRectangle As New Rectangle(PicIndex * 25, 0, 25, 23)
            If HighLightArrows Then '鼠标进入以后高亮显示，鼠标移出恢复正常。
                lblArrows.Image = My.Resources.UIResource.动态箭头_H.Clone(BitmapRectangle, Imaging.PixelFormat.Format32bppArgb)
            Else
                lblArrows.Image = My.Resources.UIResource.动态箭头.Clone(BitmapRectangle, Imaging.PixelFormat.Format32bppArgb)
            End If
            Threading.Thread.Sleep(30) '线程休息
        Loop
    End Sub

    Private Sub lblArrows_MouseEnter(sender As Object, e As EventArgs) Handles lblArrows.MouseEnter, lblArrows.MouseLeave
        HighLightArrows = Not HighLightArrows 'MouseEnter和MouseLeave时改变高亮状态的变量
    End Sub

    'Thread时间绑定的Sub过程，显示时间
    Private Sub ShowTime()
        Dim PicIndex As Integer = 0
        Dim TimeBitmap As New Bitmap(1, 1)
        Dim MyGraphics As Graphics = Graphics.FromImage(TimeBitmap)
        MyGraphics.SmoothingMode = SmoothingMode.HighQuality
        MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
        Dim BitmapRectangle As Rectangle

        Do While True
            TimeBitmap = New Bitmap(192, 34)
            MyGraphics = Graphics.FromImage(TimeBitmap)
            '获取当前系统时间
            Dim MyTime As String = My.Computer.Clock.LocalTime.TimeOfDay.ToString
            For Index As Integer = 0 To 7 '处理前8个字符
                If (MyTime.Chars(Index).ToString = ":") Then '处理冒号
                    BitmapRectangle = New Rectangle(240, 0, 24, 34)
                Else
                    PicIndex = CInt(MyTime.Chars(Index).ToString) '处理数字
                    BitmapRectangle = New Rectangle(PicIndex * 24, 0, 24, 34)
                End If
                '把从数字.png里截取的Bitmap集中绘制到主Bitmap上
                MyGraphics.DrawImage(My.Resources.UIResource.数字.Clone(BitmapRectangle, Imaging.PixelFormat.Format32bppArgb), Index * 24, 0, 24, 34)
            Next
            lblClock.Image = TimeBitmap '显示
            Threading.Thread.Sleep(1000) '休息
        Loop
    End Sub

    Private Sub MainUI_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, lbl雪豹.MouseDown, lblClock.MouseDown
        MoveWindow(Me.Handle) '鼠标左键按下拖动窗体
    End Sub

    Private Sub MainUI_Move(sender As Object, e As EventArgs) Handles Me.Move
        '窗体被拖动时，让后面的阴影窗体在相应位置跟随主窗体移动
        ShadowWindow.Left = Me.Left - ShadowWindow.ShadowSize - Math.Cos(2 * Math.PI * ShadowWindow.ShadowAngle / 360) * ShadowWindow.ShadowDistance
        ShadowWindow.Top = Me.Top - ShadowWindow.ShadowSize + Math.Sin(2 * Math.PI * ShadowWindow.ShadowAngle / 360) * ShadowWindow.ShadowDistance
    End Sub

    Private Sub lblCloseButton_Click(sender As Object, e As EventArgs) Handles lblCloseButton.Click
        Do Until Me.Opacity < 0.1
            Me.Opacity -= 0.1
            Threading.Thread.Sleep(30)
        Loop

        '点击右上角关闭按钮
        Dim CloseRectangle As New Rectangle(27, 0, 27, 27)
        lblCloseButton.Image = My.Resources.UIResource.关闭窗口.Clone(CloseRectangle, Imaging.PixelFormat.Format32bppArgb)
        '卸载线程
        Thread时间.Abort()
        Thread时间 = Nothing
        Thread雪豹.Abort()
        Thread雪豹 = Nothing
        Thread箭头.Abort()
        Thread箭头 = Nothing
        If Not (Thread进度 Is Nothing) Then
            Thread进度.Abort()
            Thread进度 = Nothing
        End If

        End
    End Sub

    Private Sub lblCloseButton_MouseDown(sender As Object, e As MouseEventArgs) Handles lblCloseButton.MouseDown
        Dim CloseRectangle As New Rectangle(54, 0, 27, 27)
        lblCloseButton.Image = My.Resources.UIResource.关闭窗口.Clone(CloseRectangle, Imaging.PixelFormat.Format32bppArgb)
    End Sub

    Private Sub lblCloseButton_MouseEnter(sender As Object, e As EventArgs) Handles lblCloseButton.MouseEnter
        Dim CloseRectangle As New Rectangle(27, 0, 27, 27)
        lblCloseButton.Image = My.Resources.UIResource.关闭窗口.Clone(CloseRectangle, Imaging.PixelFormat.Format32bppArgb)
    End Sub

    Private Sub lblCloseButton_MouseLeave(sender As Object, e As EventArgs) Handles lblCloseButton.MouseLeave
        Dim CloseRectangle As New Rectangle(0, 0, 27, 27)
        lblCloseButton.Image = My.Resources.UIResource.关闭窗口.Clone(CloseRectangle, Imaging.PixelFormat.Format32bppArgb)
    End Sub

    Private Sub lblCloseButton_MouseUp(sender As Object, e As MouseEventArgs) Handles lblCloseButton.MouseUp
        Dim CloseRectangle As New Rectangle(27, 0, 27, 27)
        lblCloseButton.Image = My.Resources.UIResource.关闭窗口.Clone(CloseRectangle, Imaging.PixelFormat.Format32bppArgb)
    End Sub

    'Thread雪豹绑定的Sub过程
    Private Sub Dynamic雪豹()
        Dim PicIndex As Integer = 0
        Do While True
            PicIndex = IIf(PicIndex = 14, 0, PicIndex + 1)
            Dim BitmapRectangle As New Rectangle(PicIndex * 124, 0, 124, 128)
            lbl雪豹.Image = My.Resources.UIResource.雪豹.Clone(BitmapRectangle, Imaging.PixelFormat.Format32bppArgb)
            Threading.Thread.Sleep(30)
        Loop
    End Sub

    Private Sub btn_加载_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_加载.MouseDown
        Dim CloseRectangle As New Rectangle(272, 0, 136, 53)
        btn_加载.Image = My.Resources.UIResource.按钮.Clone(CloseRectangle, Imaging.PixelFormat.Format32bppArgb)
    End Sub

    Private Sub btn_加载_MouseEnter(sender As Object, e As EventArgs) Handles btn_加载.MouseEnter
        Dim CloseRectangle As New Rectangle(136, 0, 136, 53)
        btn_加载.Image = My.Resources.UIResource.按钮.Clone(CloseRectangle, Imaging.PixelFormat.Format32bppArgb)
    End Sub

    Private Sub btn_加载_MouseLeave(sender As Object, e As EventArgs) Handles btn_加载.MouseLeave
        Dim CloseRectangle As New Rectangle(0, 0, 136, 53)
        btn_加载.Image = My.Resources.UIResource.按钮.Clone(CloseRectangle, Imaging.PixelFormat.Format32bppArgb)
    End Sub

    Private Sub btn_加载_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_加载.MouseUp
        Dim CloseRectangle As New Rectangle(136, 0, 136, 53)
        btn_加载.Image = My.Resources.UIResource.按钮.Clone(CloseRectangle, Imaging.PixelFormat.Format32bppArgb)
    End Sub

    Private Sub btn_加载_Click(sender As Object, e As EventArgs) Handles btn_加载.Click
        If Not (Thread进度 Is Nothing) Then Exit Sub
        Thread进度 = New Threading.Thread(AddressOf LoadProgress)
        Thread进度.Start()
        ProgressBar.Show()
    End Sub

    'Thread进度绑定的Sub过程
    Private Sub LoadProgress()
        Dim PrgBitmap As Bitmap = New Bitmap(320, 24)
        Dim PrgBody As Bitmap
        Dim PrgPoint As Bitmap = My.Resources.UIResource.进度条位置
        Dim PrgValue As Integer = 30 '进度条的初始值为30
        Dim MyGraphics As Graphics = Graphics.FromImage(PrgBitmap)
        MyGraphics.SmoothingMode = SmoothingMode.HighQuality
        MyGraphics.CompositingQuality = CompositingQuality.HighQuality

        Do While PrgValue < 290
            PrgBitmap = New Bitmap(320, 24)
            MyGraphics = Graphics.FromImage(PrgBitmap) '画笔绑定PrgBitmap
            PrgBody = New Bitmap(My.Resources.UIResource.进度条, PrgValue, 24) '拉伸进度条的蓝色线条
            MyGraphics.DrawImage(PrgBody, 0, 0, PrgValue, 24) '绘制蓝色线条部分
            MyGraphics.DrawImage(PrgPoint, PrgValue - 60, 0, 120, 24) '绘制顶端发光点部分
            ProgressBar.Image = PrgBitmap
            ProgressBar.Text = "Loading... " & FormatPercent(PrgValue / 290, 2) '显示当前进度的文本
            Threading.Thread.Sleep(5)
            PrgValue += 1 '进度条的Value增加
        Loop
        '进度条满了...
        ProgressBar.Image = Nothing
        ProgressBar.Text = "Loaded. 100% "
        '开启动态背景的线程，开启之前需要卸载之前正在运行的背景线程
        If Not (Thread背景 Is Nothing) Then
            Thread背景.Abort()
            Thread背景 = Nothing
        End If
        '开启咯
        Thread背景 = New Threading.Thread(AddressOf ChangeWallpaper)
        WallpaperIndex = IIf(WallpaperIndex = 1, 2, 1)
        Thread背景.Start()

        Thread进度 = Nothing
    End Sub

    '动态的背景（Thread背景）
    Private Sub ChangeWallpaper()
        Dim PicLeft As Integer = My.Resources.UIResource.Backgroud1.Width \ 2
        Dim D_Value As Integer = 1
        Dim WallpaperBitmap As Bitmap = IIf(WallpaperIndex = 1, My.Resources.UIResource.Backgroud1, My.Resources.UIResource.Backgroud2)
        Dim BitmapRectangle As Rectangle

        Do While True
            BitmapRectangle = New Rectangle(PicLeft, 0, 320, 480)
            Me.BackgroundImage = WallpaperBitmap.Clone(BitmapRectangle, Imaging.PixelFormat.Format32bppArgb)
            '窗体的背景首先从中间位置向左移动至图片边缘后，变向向右移动，到达边缘后继续变向
            If PicLeft = 0 Then
                D_Value = 1
            ElseIf PicLeft = WallpaperBitmap.Width - Me.Width Then
                D_Value = -1
            End If
            PicLeft += D_Value

            Threading.Thread.Sleep(50)
        Loop
    End Sub

End Class