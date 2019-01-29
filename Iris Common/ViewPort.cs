﻿using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace common
{
    public class ViewPort : INotifyPropertyChanged
    {
        private Bitmap image;
        private string name, description, host;
        private int port, screenX, sizeX, screenY, sizeY, posX, posY;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public string Host
        {
            get { return host; }
            set
            {
                host = value;
                NotifyPropertyChanged("Host");
            }
        }

        public int Port
        {
            get { return port; }
            set
            {
                port = value;
                NotifyPropertyChanged("Port");
            }
        }

        public int ScreenCaptureX
        {
            get { return screenX; }
            set
            {
                screenX = value;
                NotifyPropertyChanged("ScreenCaptureX");
            }
        }

        public int ScreenCaptureY
        {
            get { return screenY; }
            set
            {
                screenY = value;
                NotifyPropertyChanged("ScreenCaptureY");
            }
        }

        public int SizeX
        {
            get { return sizeX; }
            set
            {
                sizeX = value;
                changeBitmapSize();
                NotifyPropertyChanged("SizeX");
            }
        }

        public int SizeY
        {
            get { return sizeY; }
            set
            {
                sizeY = value;
                changeBitmapSize();
                NotifyPropertyChanged("SizeY");
            }
        }

        public int ScreenPositionX
        {
            get { return posX; }
            set
            {
                posX = value;
                NotifyPropertyChanged("ScreenPositionX");
            }
        }

        public int ScreenPositionY
        {
            get { return posY; }
            set
            {
                posY = value;
                NotifyPropertyChanged("ScreenPositionY");
            }
        }

        [XmlIgnoreAttribute]
        public Bitmap Image
        {
            get { return image; }
            set
            {
                image = value;
                NotifyPropertyChanged("Image");
            }
        }

        private void changeBitmapSize()
        {
            if ((sizeX > 0) & (sizeY > 0))
            {
                image = new Bitmap(sizeX, sizeY);
                NotifyPropertyChanged("Image");
            }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Bitmap capture()
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CopyFromScreen(screenX, screenY, 0, 0, new Size(sizeX, sizeY));
            }
            NotifyPropertyChanged("Image");
            return image;
        }

    }
}
