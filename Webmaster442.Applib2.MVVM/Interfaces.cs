﻿namespace Webmaster442.Applib
{

    /// <summary>
    /// Abstract interface
    /// </summary>
    public interface IView
    {

    }

    /// <summary>
    /// A View that can be closed
    /// </summary>
    public interface ICloseableView : IView
    {
        /// <summary>
        /// Close the view
        /// </summary>
        void Close();
    }


    /// <summary>
    /// A generic View Interface
    /// </summary>
    public interface IView<Model>: IView
    {
        /// <summary>
        /// View Model reference 
        /// </summary>
        Model ViewModel { get; }
    }

    /// <summary>
    /// A View that can be closed
    /// </summary>
    public interface ICloseableView<Model>: IView<Model>
    {
        /// <summary>
        /// Close the view
        /// </summary>
        void Close();
    }
}
