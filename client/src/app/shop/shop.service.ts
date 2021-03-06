import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { IPagination } from '../shared/models/pagination';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ISize } from '../shared/models/productSize';

import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(shopParams : ShopParams) {
    let params = new HttpParams();

    if (shopParams.typeId !==0)
    {
      params = params.append('typeId', shopParams.typeId.toString());
    }
    if(shopParams.search) {
      params = params.append('search', shopParams.search);
    }
    
    
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params})
        .pipe(
          map(response => {
            return response.body;
          })
        );
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }

  getSizes () {
    return this.http.get<ISize[]>(this.baseUrl + 'products/sizes');
  }
  getTypes () {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }

}
