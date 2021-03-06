﻿using UnityEngine;

namespace Assets.Patterns
{
    /// <summary>
    /// Creates an array of vectors in the shape of a Lorenz system
    /// see https://en.wikipedia.org/wiki/Lorenz_system
    /// </summary>
    public class Lorenz : Pattern
    {
        #region Properties
        //starting system state
        public float x { get; private set; }
        public float y { get; private set; }
        public float z { get; private set; }

        //system parameters
        public float sigma { get; private set; }
        public float rho { get; private set; }
        public float beta { get; private set; }
        public float dt { get; private set; }
        #endregion

        #region Constructor 
        public Lorenz(int numPoints) : base(numPoints)
        {
        }
        #endregion

        #region Builder Methods
        /// <summary>
        /// Coordinates for the starting state
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetState(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Sets the system parameters
        /// </summary>
        /// <param name="sigma"></param>
        /// <param name="rho"></param>
        /// <param name="beta"></param>
        /// <param name="dt"></param>
        public void SetParameters(float sigma, float rho, float beta, float dt)
        {
            this.sigma = sigma;
            this.rho = rho;
            this.beta = beta;
            this.dt = dt;
        }

        /// <summary>
        /// Adds a vector to the Points list (from the base class) for each coordinate
        /// </summary>
        public override void AddPoints()
        {
            float dx = 0, dy = 0, dz = 0;

            for (int i = 0; i < Size; i++)
            {
                dx = (sigma * (y - x)) * dt;
                dy = (x * (rho - z) - y) * dt;
                dz = (x * y - beta * z) * dt;

                x = x + dx;
                y = y + dy;
                z = z + dz;

                Points.Add(new Vector3(x, y, z));
            }
        }
        #endregion
    }
}
