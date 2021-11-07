using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CheckMate
{
    /// <summary>
    /// InputManager registers Player inputs and notifies corresponding listeners
    /// </summary>
    public class InputManager
    {
        private List<IKeyListener> _listeners;
        private List<MouseButton>  _clicks;

        /// <summary>
        /// InputManager constructor holds a list of all MouseButton keys
        /// </summary>
        public InputManager()
        {
            _listeners = new List<IKeyListener>();
            _clicks = new List<MouseButton>
            {
                MouseButton.LeftButton,
                MouseButton.RightButton
            };
        }

        /// <summary>
        /// Loop over List of keys and notify the listeners
        /// </summary>
        public void CheckInput()
        {
            foreach (MouseButton mouse in _clicks)
            {
                if (SplashKit.MouseClicked(mouse))
                    NotifyListeners(mouse);
            }
        }

        /// <summary>
        /// Ask the listeners to execute the OnMouseClick method
        /// </summary>
        /// <param name="mouse"></param>
        public void NotifyListeners(MouseButton mouse)
        {
            foreach (IKeyListener listener in _listeners)
                listener.OnMouseClick(mouse);
        }

        /// <summary>
        /// Add a listener
        /// </summary>
        /// <param name="listener"></param>
        public void Add(IKeyListener listener)
            => _listeners.Add(listener);

        public void Remove(IKeyListener listener)
            => _listeners.Remove(listener);
    }
}
