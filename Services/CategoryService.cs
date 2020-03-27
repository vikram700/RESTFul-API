using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services.Communication;
using Supermarket.API.Persistence.Repositories;

namespace Supermarket.API.Services
{
    public class CategoryService : ICategoryService
    {   
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitofWork _unitofWork;
        public CategoryService(ICategoryRepository categoryRepository,
                                IUnitofWork unitofWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitofWork = unitofWork;
        }
        public async Task<IEnumerable<Category > > ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<SaveCategoryResponse > PostAsync(Category category)
        {   
            try
            {
                await _categoryRepository.PostAsync(category);
                await _unitofWork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }
            catch(Exception ex)
            {
                return new SaveCategoryResponse($"An error occured while saving the category : {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponse > PutAsync(int id, Category category)
        {
            var existingCategory = _categoryRepository.FindById(id).Result;

            if(existingCategory == null)
            {
                return new SaveCategoryResponse("category not found");
            }

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitofWork.CompleteAsync();

                return new SaveCategoryResponse(existingCategory);
            }
            catch(Exception ex)
            {
                return new SaveCategoryResponse($"An error has been occured while updating the category : {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponse > DeleteAsync(int id)
        {
            var category = await _categoryRepository.FindById(id);

            if(category == null)
                return new SaveCategoryResponse($"there is no category with given id");

            try
            {
                _categoryRepository.Delete(category);
                await _unitofWork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }
            catch(Exception ex)
            {
                return new SaveCategoryResponse($"An error has been occured while deleting the category : {ex.Message}");
            }
        }
    }
}