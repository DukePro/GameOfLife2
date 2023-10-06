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

            _currentGeneration = 0;
            Text = $"Generation {_currentGeneration}";
            bPause.Text = "Pause";
            bStart.Text = "Restart";

            nudResolution.Enabled = false;
            nudDencity.Enabled = false;

            _resolution = (int)nudResolution.Value;
            _rows = pictureBox1.Height / _resolution;
            _columns = pictureBox1.Width / _resolution;
            _field = new bool[_columns, _rows];

            Random _random = new Random();

            _history.Clear();
            _history.Push(_field);

            for (int x = 0; x < _columns; x++)
            {
                for (int y = 0; y < _rows; y++)
                {
                    _field[x, y] = _random.Next((int)nudDencity.Value) == 0;
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

        private void GenerateCells()
        {
            _graphics.Clear(Color.White);
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
                        _graphics.FillRectangle(Brushes.Black, x * _resolution, y * _resolution, _resolution, _resolution);
                    }
                }
            }

            _field = newField;



            _history.Push(_field);
            tBarGeneration.Maximum = _history.Count - 1; // Обновляем максимальное значение ползунка

            pictureBox1.Refresh();
            Text = $"Generation {++_currentGeneration}";
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled && _isPaused == false)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X / _resolution;
                int y = e.Location.Y / _resolution;
                bool validationPassed = ValidateMousePos(x, y);

                if (validationPassed)
                {
                    _field[x, y] = true;
                    RedrawField();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                int x = e.Location.X / _resolution;
                int y = e.Location.Y / _resolution;
                bool validationPassed = ValidateMousePos(x, y);

                if (validationPassed)
                {
                    _field[x, y] = false;
                    RedrawField();
                }
            }
        }

        private void RedrawField()
        {
            _graphics.Clear(Color.White);

            for (int x = 0; x < _columns; x++)
            {
                for (int y = 0; y < _rows; y++)
                {
                    if (_field[x, y])
                    {
                        _graphics.FillRectangle(Brushes.Black, x * _resolution, y * _resolution, _resolution, _resolution);
                    }
                }
            }

            pictureBox1.Refresh();
        }

        private bool ValidateMousePos(int x, int y)
        {
            return x >= 0 && y >= 0 && x < _columns && y < _rows;
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpeedFromControls();
            UpdateTrackBarFromControls();
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

        //Пофиксить блокировку настроек (Сделать кнопку старт стоп и рестарт одной)
        //Реализовать удаление неактуальной истории если игра продолжена с перемотки.
        //Реализовать Добавление фигур
        //Реализовать картинки вместо пикселей
    }
}