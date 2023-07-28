import { RESOURCE_VALIDATIONS } from "./ResourceFormValidationConstants";

export const resourceFormValidator = (resource) => {
    const errors = {};
  
    if (resource.title.length < resourceFormValidator.TITLE_MIN_LENGTH || resource.title.length > RESOURCE_VALIDATIONS.TITLE_MAX_LENGTH) {
      errors.title = `Title must be between ${RESOURCE_VALIDATIONS.TITLE_MIN_LENGTH} and ${RESOURCE_VALIDATIONS.TITLE_MAX_LENGTH} characters long`;
    }
  
    if (resource.content.length < RESOURCE_VALIDATIONS.CONTENT_MIN_LENGTH || resource.content.length > RESOURCE_VALIDATIONS.CONTENT_MAX_LENGTH) {
      errors.content = `Content must be between ${RESOURCE_VALIDATIONS.CONTENT_MIN_LENGTH} and ${RESOURCE_VALIDATIONS.CONTENT_MAX_LENGTH} characters long`;
    }
  
    if (resource.imageUrl.length < RESOURCE_VALIDATIONS.IMAGEURL_MIN_LENGTH || resource.imageUrl.length > RESOURCE_VALIDATIONS.IMAGEURL_MAX_LENGTH) {
      errors.imageUrl = `Image URL must be between ${RESOURCE_VALIDATIONS.IMAGEURL_MIN_LENGTH} and ${RESOURCE_VALIDATIONS.IMAGEURL_MAX_LENGTH} characters long`;
    }
    if(resource.chosenCategories.length===0){
        errors.chosenCategories = "You must have selected at least one category";
    }
    return errors;
  };