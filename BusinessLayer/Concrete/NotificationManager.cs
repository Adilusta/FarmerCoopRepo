using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Delete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> GetAll(Expression<Func<Notification, bool>> filter = null)
        {
          return  _notificationDal.GetAll(filter);
        }

        public Notification GetEntity(Expression<Func<Notification, bool>> filter)
        {
            return _notificationDal.GetEntity(filter);
        }

        public Notification GetEntityByID(int id)
        {
            return _notificationDal.GetEntityByID(id);
        }

        public void Insert(Notification entity)
        {
           _notificationDal.Insert(entity);
        }

        public void Update(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
