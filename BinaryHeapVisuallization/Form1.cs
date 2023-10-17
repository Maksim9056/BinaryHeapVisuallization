using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryHeapVisuallization
{
    public partial class Form1 : Form
    {
        private List<int> heap;
        private int numLevels;
        private int maxElements;
        private int width;
        private int height;
        private float deltaX;
        private float deltaY;


        /// <summary>
        /// Основной класс
        /// </summary>
        BinaryHeap<int> binaryHeap = new BinaryHeap<int>() ;

        /// <summary>
        /// Исходник
        /// </summary>
        List<int> numbers = new List<int> { 4, 8, 10, 20, 5, 6, 13, 12, 25, 15, 14, 0, 26, 9, 3, 1, 19, 2, 24, 28, 17, 23, 27, 7, 11, 29, 21, 30, 22, 18, 16 };

        public List<int> AddHeap = new List<int>();

        /// <summary>
        /// Клас для минимальной сортировки 
        /// </summary>
        Binary<int> binary = new Binary<int>();

        /// <summary>
        /// Форму инициализируем
        /// </summary>
        public Form1()
        {
            InitializeComponent();

        }


        

        /// <summary>
        /// Инициализация для рисования
        /// </summary>
        private void InitializeForm()
        {
            this.Invalidate(); // Добавьте эту строку для обновления контрола рисования

            ClientSize = new Size(width, height);
            Paint += OnPaint;
        }

        /// <summary>
        /// Рисует
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPaint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);

            Graphics graphics = e.Graphics;
            Brush brush = Brushes.Red;
            Font font = new Font("Helvetica", 8);
            Pen pen = Pens.Black;

            for (int i = 0; i < heap.Count; i++)
            {
                int level = (int)Math.Floor(Math.Log(i + 1, 2) + 1);
                float x = deltaX * level;
                float y = height - (deltaY * (i + 1));

                //   graphics.FillEllipse(brush, x - 10, y - 10, 20, 20);
                graphics.FillEllipse(brush, x - 10, y - 10, 20, 20);
                graphics.DrawEllipse(pen, x - 10, y - 10, 20, 20);
                x -= 5;
                y -= 6;
                graphics.DrawString(heap[i].ToString(), font, Brushes.Black, x, y);

                if (i > 0)
                {
                    int parent = (int)Math.Floor((i - 1) / 2f);
                    int parentLevel = (int)Math.Floor(Math.Log(parent + 1, 2) + 1);
                    float parentX = deltaX * parentLevel;
                    float parentY = height - (deltaY * (parent + 1));

                    graphics.DrawLine(pen, parentX, parentY, x, y);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (binaryHeap._heap.Count == 0)
                {
                    binaryHeap = new BinaryHeap<int>(numbers);
                }

                this.heap = binaryHeap._heap;

                binary._heap = binaryHeap._heap;
                numLevels = (int)Math.Ceiling(Math.Log(heap.Count + 1, 2));
                maxElements = (int)Math.Pow(2, numLevels) - 1;
                width = 800;
                height = 600;
                deltaX = width / (float)(numLevels + 1);
                deltaY = height / (float)(heap.Count + 1);

                InitializeForm();
                //this.heap.Clear();
            }
            catch(Exception)
            {

            }

        }

        /// <summary>
        /// Добавляет элемент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Добавить(object sender, EventArgs e)
        {
            try
            {
                if (!binaryHeap._heap.Any(q => q ==int.Parse( textBox1.Text)))
                {
                    binaryHeap.Insert(int.Parse(textBox1.Text));
                    label1.Text += textBox1.Text + ",";
                    textBox1.Text = "";
                }
             
            }
            catch(Exception) 
            { 
            }
        }

        /// <summary>
        /// Сортирует по минимальному элементу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortMin(object sender, EventArgs e)
        {
            if(binaryHeap._heap.Count == 0)
            {
                binaryHeap = new BinaryHeap<int>(numbers);

            }
            binary._heap = binaryHeap._heap;
            while (binaryHeap.Size > 0)
            {
                binary.HeapSort();
                int min = binary.ExtractMin();
            //    int min = binaryHeap.ExtractMin();
                binaryHeap.Min.Add(min);
                Console.WriteLine($"Priority: {min}");
            }

            this.heap = binaryHeap.Min;
            numLevels = (int)Math.Ceiling(Math.Log(heap.Count + 1, 2));
            maxElements = (int)Math.Pow(2, numLevels) - 1;
            width = 1000;
            height = 700;
            deltaX = width / (float)(numLevels + 1);
            deltaY = height / (float)(heap.Count + 1);

            InitializeForm();
           // this.heap.Clear();

        }

        /// <summary>
        /// Сортирует по Максимальному элементу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortMax(object sender, EventArgs e)
        {
            if (binaryHeap._heap.Count == 0)
            {
                binaryHeap = new BinaryHeap<int>(numbers);

            }

            while (binaryHeap.Size > 0)
            {
                binaryHeap.BuildHeap();
                int min = binaryHeap.ExtractMax();
                binaryHeap.Max.Add(min);

                Console.WriteLine($"Priority: {min}");
            }
            this.heap = binaryHeap.Max;
            numLevels = (int)Math.Ceiling(Math.Log(heap.Count + 1, 2));
            maxElements = (int)Math.Pow(2, numLevels) - 1;
            width = 700;
            height = 800;
            deltaX = width / (float)(numLevels + 1);
            deltaY = height / (float)(heap.Count + 1);

            InitializeForm();

           // this.heap.Clear();

        }


        /// <summary>
        /// Отчищает форму  фон нарисованый 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear(object sender, EventArgs e)
        {
                using (Graphics graphics = CreateGraphics())
                {
                    graphics.Clear(BackColor);
                }
            
        }

    }
}
