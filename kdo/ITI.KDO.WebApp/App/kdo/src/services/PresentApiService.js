import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper';

const endpoint = "/api/present";

class PresentApiService{
    constructor(){

    }

    async getPresentListAsync(){
        return await getAsync(endpoint);
    }

    async getPresentAsync(presentId){
        return await getAsync(`${endpoint}/${presentId}`);
    }

    async createPresentAsync(model){
        return await postAsync(endpoint, model);
    }

    async updatePresentAsync(model){
        return await putAsync(`${endpoint}/${model.presentId}`, model)
    }

    async deletePresentAsync(presentId) {
        return await deleteAsync(`${endpoint}/${presentId}`);
    }
}

export default new PresentApiService()