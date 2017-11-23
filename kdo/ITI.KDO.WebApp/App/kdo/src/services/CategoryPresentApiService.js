import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper';

const endpoint = "/api/categoryPresent";

class CategoryPresentApiService{
    constructor(){

    }

    async getCategoryPresentListAsync(){
        return await getAsync(`${endpoint}/getPresentByUserId`);
    }
}

export default new CategoryPresentApiService()