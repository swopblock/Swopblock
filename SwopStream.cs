using System;
using System.Numerics;

namespace swop
{
	public class SwopStream
	{
		//System
		public SwopStream()
		{
		}

        //Method Description
        //Starts fast play of the order in the forward direction.
        public void FastForward() { }

        //Starts fast play of the order in the reverse direction.
        public void FastReverse() { }

        //Sets the genesis order in the order list as the current order.
        public void Genesis() { }

        //Sets the next order in the order list as the current order.
        public void Next() { }

        //Pauses playback of the order.
        public void Pause() { }

        //Begins playback of the current order, or resumes playback of a paused order.
        public void Play() { }

        //Plays the specified order.
        public void PlayItem() { }

        //Sets the previous item in the order list as the current order.
        public void Previous() { }

        //Stops playback of the order.
        public void Stop() { }

    }
}

