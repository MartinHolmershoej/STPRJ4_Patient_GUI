using System;
using System.Collections.Generic;
using Logic_Layer.Interface;

namespace Logic_Layer
{
    public abstract class Subject 
    {
        private List<IObserver_GUI> iobserver = new List<IObserver_GUI>();

        
        /// <summary>
        /// Denne metode attacher en opserver til listen, så når der sker en ændring i state, så bliver alle der lytter automatisk opdateret. 
        /// </summary>
        /// <param name="Observer"></param>
        public void Attach(IObserver_GUI Observer)
        {
            iobserver.Add(Observer);
        }

        public void Detach(IObserver_GUI Observer)
        {
            iobserver.Remove(Observer);

        }

        protected void NotifyGui(object obj)
        {
            foreach (var observer in iobserver)
            {
                observer.Update(obj);
            }

        }
    }
}
