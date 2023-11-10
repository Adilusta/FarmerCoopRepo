
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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Delete(Message entity)
        {
           _messageDal.Delete(entity);
        }

        public List<Message> GetAll(Expression<Func<Message, bool>> filter = null)
        {
          return  _messageDal.GetAll(filter);
        }

        public Message GetEntity(Expression<Func<Message, bool>> filter)
        {
           return _messageDal.GetEntity(filter);
        }

        public Message GetEntityByID(int id)
        {
          return _messageDal.GetEntityByID(id);
        }

        public void Insert(Message entity)
        {
           _messageDal.Insert(entity);
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
