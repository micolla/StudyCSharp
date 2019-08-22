using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2_Lesson2.GameObjects.AbstractClasses;
using Level2_Lesson2.GameObjects.ActiveObjects;

namespace Level2_Lesson2.GameObjects.ActiveObjects
{
    class SpaceShuttle : ActiveObject
    {
        public event Action ShuttleDieEvent;
        public event Action ShuttleEnergyLowEvent;
        Image img_src;
        private Stack<Bullet> clip;
        private BulletPower bulletsPower;
        private BulletSpeed bulletsSpeed;
        public int Energy { get; private set; }
        public int Health { get; private set; }
        private int energyRegenration;
        private int iter;

        public SpaceShuttle(Point pos, Size size, Image img) : base(pos, size)
        {
            img_src = img;
            base.Power = 48;
            clip = new Stack<Bullet>();
            bulletsPower = BulletPower.PowerFull;
            bulletsSpeed = BulletSpeed.Fast;
            Energy = 100;
            Health = 100;
            energyRegenration = 15;

    }
    /// <summary>
    /// Изменить энергию коробля в случае выстрела или с течением времени
    /// </summary>
    /// <param name="deltaEnergy">Величина изменения энергии</param>
    public void ChangeEnergy(int deltaEnergy)
        {
            Energy += deltaEnergy;
            if (Energy <= 0)
            {
                ShuttleEnergyLowEvent?.Invoke();
            }
            else if (Energy > 100)
            {
                Energy = 100;
            }
        }
        /// <summary>
        /// Изменить здоровье коробля в случае столкновения или лечения
        /// </summary>
        /// <param name="deltaHealth">Величина изменения здоровья</param>
        public void ChangeHealth(int deltaHealth)
        {
            Health += deltaHealth;
            if (Health <= 0)
            {
                ShuttleDieEvent?.Invoke();
            }
            else if (Health > 100)
            {
                Health = 100;
            }
            base.WriteLog($"ShuttleHealthChanged:{Health}");
        }
        /// <summary>
        /// Отрисовка шатла с помощью изображения
        /// </summary>
        public override void Draw(BufferedGraphics b)
        {
            b.Graphics.DrawImage(this.img_src, base.Rect.X, base.Rect.Y, base.Rect.Width, base.Rect.Height);
        }
        /// <summary>
        /// Перемещения Шатала по заданному направлению
        /// </summary>
        public override void Update()
        {
            if(iter<energyRegenration)
                iter++;
            else
            {
                iter = 0;
                ChangeEnergy(1);
            }
        }
        /// <summary>
        /// Перемещение шатла на заданное растояние
        /// </summary>
        /// <param name="moveX">отклонение по оси Х</param>
        /// <param name="moveY">отклонение по оси Y</param>
        public void MoveShuttle(int moveX, int moveY)
        {
            base.Move(moveX,moveY);
            base.WriteLog($"ShuttleHealthNewPosition:{Rect.X},{Rect.Y}");
        }
        /// <summary>
        /// Заглушка для стрельбы шатлом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public Bullet Shoot()
        {
            Bullet tmpBull;
            if (Energy < (int)bulletsPower)
            {
                tmpBull =null;
                ShuttleEnergyLowEvent?.Invoke();
                base.WriteLog($"ShuttleEnergyLow:{Energy}");
            }
            else
            {
                if (clip.Count == 0)
                    tmpBull = new Bullet(new Point(base.Rect.X + base.Rect.Width, base.Rect.Y + base.Rect.Height / 2), this.bulletsSpeed, this.bulletsPower, new Size(4, 2));
                else
                {
                    tmpBull = clip.Pop();
                    tmpBull.ChangeLocation(base.Rect.X + base.Rect.Width, base.Rect.Y + base.Rect.Height / 2);
                    tmpBull.ChangePowerSpeed(this.bulletsSpeed, this.bulletsPower);
                }
                tmpBull.BulletIsOut += FillClip;
                ChangeEnergy(-tmpBull.Power);
                base.WriteLog($"Shuttle Shoot:bulletPower{tmpBull.Power}");
            }
            return tmpBull;
        }
        /// <summary>
        /// Пополнить обойму для регенерации объектов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillClip(object sender, EventArgs e)
        {
            if(sender is Bullet)
            {
                (sender as Bullet).BulletIsOut -= FillClip;
                clip.Push(sender as Bullet);
            }
        }
        /// <summary>
        /// Вызввать обработчик 
        /// </summary>
        /// <param name="power">Мощность вражеского объекта</param>
        public override void Distruct(int power)
        {
            ChangeHealth(-power);
            if (Health <= 0)
                ShuttleDieEvent?.Invoke();
        }
    }
}
