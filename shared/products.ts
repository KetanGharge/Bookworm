import { IProducts } from './iproducts';

export class Products implements IProducts {

    constructor(    
     public productid : number,
    public producttitle : string, 
    public price : number  ,
    public islibrary : boolean,
    public rentcost : number ,
    public rentmindays: number  ,
    public shortdescription : string,
    public longdescription : string,
    public imgurl : string,
    public producturl: string,
    public avgrating : string,
    public isrent : boolean,
    public author_authorid : number,
    public  category_categoryid: number ,
    public  language_languageid : number,
    public producttype_producttypeid: number
    )
    {}


}
