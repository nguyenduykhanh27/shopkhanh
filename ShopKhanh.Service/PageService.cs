using System;
using ShopKhanh.Data.Infrastructure;
using ShopKhanh.Data.Repositories;
using ShopKhanh.Model.Models;
using System.Collections.Generic;

namespace ShopKhanh.Service
{
    public interface IPageService
    {
        Page Add(Page page);
        void Update(Page page);
        void Save();
        IEnumerable<Page> GetAll(); 
        IEnumerable<Page> GetAll(string keyword);
        Page GetById(int id);
        Page GetByAlias(string alias);
    }

    public class PageService : IPageService
    {
        private IPageRepository _pageRepository;
        private IUnitOfWork _iuniOfWork;

        public PageService(IPageRepository pageRepository, IUnitOfWork iunitOfWork)
        {
            this._pageRepository = pageRepository;
            this._iuniOfWork = iunitOfWork;
        }

        public Page GetByAlias(string alias)
        {
            return _pageRepository.GetSingleByCondution(x => x.Alias == alias);
        }

        public Page Add(Page page)
        {
            return _pageRepository.Add(page);
        }

        public void Update(Page page)
        {
            _pageRepository.Update(page);
        }

        public void Save()
        {
            _iuniOfWork.Commit();
        }

        public IEnumerable<Page> GetAll()
        {
            return _pageRepository.GetAll();
        }

        public IEnumerable<Page> GetAll(string keyword)
        {

            if (!string.IsNullOrEmpty(keyword))
                return
                    _pageRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _pageRepository.GetAll();
        }

        public Page GetById(int id)
        {
            return _pageRepository.GetSingleById(id);
        }
    }
}