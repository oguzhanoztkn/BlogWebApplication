using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messagelDal;

        public MessageManager(IMessageDal messagelDal)
        {
            _messagelDal = messagelDal;
        }

        public Message GetByID(int id)
        {
            return _messagelDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messagelDal.List(x => x.ReceiverMail ==p );
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messagelDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _messagelDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
