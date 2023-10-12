using System.Drawing.Drawing2D;

namespace GameOfLife2
{
    public partial class Form1 : Form
    {
        private Graphics _graphics;
        private int _currentGeneration = 0;
        private int _resolution;
        private int _rows;
        private int _columns;
        private bool[,] _field;
        private bool _isPaused = false;
        private bool _updatingSpeed = false;
        private bool _isMouseDown = false;
        private bool _isRandom = true;
        private Stack<bool[,]> _history = new Stack<bool[,]>();

        public Form1()
        {
            InitializeComponent();
            _graphics = pictureBox1.CreateGraphics();
        }

        private void StartGame()
        {
            if (timer1.Enabled)
            {
                EndGame();
            }
            
            RedrawField();
            _currentGeneration = 0;
            Text = $"Generation {_currentGeneration}";
            bPause.Text = "Pause";
            bStart.Text = "Restart";

            //cBoxRandom.Enabled = false;
            //nudResolution.Enabled = false;
            //nudDencity.Enabled = false;

            _resolution = (int)nudResolution.Value;
            _rows = pictureBox1.Height / _resolution;
            _columns = pictureBox1.Width / _resolution;
            _field = new bool[_columns, _rows];

            Random _random = new Random();
            
            _history.Clear();
            _history.Push(_field);

            if (_isRandom == true)
            {
                for (int x = 0; x < _columns; x++)
                {
                    for (int y = 0; y < _rows; y++)
                    {
                        _field[x, y] = _random.Next((int)nudDencity.Value) == 0;
                    }
                }
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
            
        }

        private void EndGame()
        {
            if (!timer1.Enabled)
            {
                return;
            }

            timer1.Stop();
            nudResolution.Enabled = true;
            nudDencity.Enabled = true;
            bPause.Text = "Pause";
        }

        private void PauseGame()
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                _isPaused = true;
                bPause.Text = "Resume";
            }
            else if (_isPaused == true)
            {
                timer1.Start();
                _isPaused = false;
                bPause.Text = "Pause";
            }
        }

        private void DrawGrid()
        {
            if (_resolution > 1)
            {
                if (_resolution > 2)
                {
                    _graphics.SmoothingMode = SmoothingMode.HighQuality;
                }

                Pen gridPen = new Pen(Color.FromArgb(51, 51, 51));
                int cellSize = _resolution;

                for (int x = 0; x < pictureBox1.Width; x += cellSize)
                {
                    _graphics.DrawLine(gridPen, x, 0, x, pictureBox1.Height);
                }

                for (int y = 0; y < pictureBox1.Height; y += cellSize)
                {
                    _graphics.DrawLine(gridPen, 0, y, pictureBox1.Width, y);
                }
            }
        }

        private void GenerateCells()
        {
            _graphics.Clear(Color.Black);
            var newField = new bool[_columns, _rows];
            timer1.Interval = (int)nudSpeed.Value;

            for (int x = 0; x < _columns; x++)
            {
                for (int y = 0; y < _rows; y++)
                {
                    int neighboursCount = CountClosestCells(x, y);
                    bool hasLife = _field[x, y];

                    if (!hasLife && neighboursCount == 3)
                    {
                        newField[x, y] = true;
                    }
                    else if (hasLife && (neighboursCount < 2 || neighboursCount > 3))
                    {
                        newField[x, y] = false;
                    }
                    else
                    {
                        newField[x, y] = _field[x, y];
                    }
                    if (hasLife == true)
                    {
                        DrawCell(x, y);
                    }
                }
            }

            _field = newField;
            _history.Push(_field);
            tBarGeneration.Maximum = _history.Count - 1;

            DrawGrid();

            pictureBox1.Refresh();
            Text = $"Generation {++_currentGeneration}";
            
            if (_isPaused)
            {
                PauseGame();
            }
        }

        private void DrawCell(int x, int y)
        {
            if (!_isPaused)
            {
                _graphics.SmoothingMode = SmoothingMode.HighQuality;
            }
            else
            {
                _graphics.SmoothingMode = SmoothingMode.None;
            }

            using (SolidBrush brush = new SolidBrush(Color.LimeGreen))
            {
                _graphics.FillRectangle(brush, x * _resolution, y * _resolution, _resolution, _resolution);
            }
        }

        private int CountClosestCells(int x, int y)
        {
            int count = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (x + i + _columns) % _columns;
                    int row = (y + j + _rows) % _rows;

                    bool isSelfCheck = col == x && row == y;
                    bool hasLife = _field[col, row];

                    if (hasLife && !isSelfCheck)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"Generation {_currentGeneration}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GenerateCells();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void bPause_Click(object sender, EventArgs e)
        {
            PauseGame();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                UserDraw(sender, e);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                UserDraw(sender, e);
            }
        }

        private void UserDraw(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled && _isPaused == false)
            {
                return;
            }

            int x = e.Location.X / _resolution;
            int y = e.Location.Y / _resolution;
            bool validationPassed = ValidateMousePos(x, y);

            if (validationPassed)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _field[x, y] = true;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    _field[x, y] = false;
                }

                RedrawField();
            }
        }

        private void RedrawField()
        {
            _graphics.Clear(Color.Black);

            for (int x = 0; x < _columns; x++)
            {
                for (int y = 0; y < _rows; y++)
                {
                    if (_field[x, y])
                    {
                        DrawCell(x, y);
                    }
                }
            }

            DrawGrid();
            pictureBox1.Refresh();
        }

        private bool ValidateMousePos(int x, int y)
        {
            return x >= 0 && y >= 0 && x < _columns && y < _rows;
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBarFromControls();
            UpdateSpeedFromControls();
        }

        private void tBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpeedFromControls();
            UpdateTrackBarFromControls();
        }

        private void UpdateSpeedFromControls()
        {
            if (!_updatingSpeed)
            {
                int trackBarValue = tBarSpeed.Value;
                nudSpeed.ValueChanged -= nudSpeed_ValueChanged;
                nudSpeed.Value = trackBarValue;
                nudSpeed.ValueChanged += nudSpeed_ValueChanged;
                timer1.Interval = trackBarValue;
            }
        }

        private void UpdateTrackBarFromControls()
        {
            if (!_updatingSpeed)
            {
                int numericUpDownValue = (int)nudSpeed.Value;
                tBarSpeed.ValueChanged -= tBarSpeed_ValueChanged;
                tBarSpeed.Value = numericUpDownValue;
                tBarSpeed.ValueChanged += tBarSpeed_ValueChanged;
                timer1.Interval = numericUpDownValue;
            }
        }

        private void tBarGeneration_ValueChanged(object sender, EventArgs e)
        {
            int value = tBarGeneration.Value;
            if (value < _history.Count)
            {
                _field = _history.ElementAt(value);
                RedrawField();
            }
        }

        private void cBoxRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxRandom.Checked) 
            {
                _isRandom = true;
            }
            else
            {
                _isRandom = false;
                _isPaused = true;
            }
        }

        //Реализовать старт как с рандомным расположением точек, так и с предварительно нарисованными
        //Реализовать удаление неактуальной истории если игра продолжена с перемотки.
        //Реализовать Добавление фигур
    }
}