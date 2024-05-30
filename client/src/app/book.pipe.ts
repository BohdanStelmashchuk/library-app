import {Pipe, PipeTransform} from "@angular/core";
import {BookModel} from "./models/bookModel";

@Pipe({name: 'book'})
export class BookPipe implements PipeTransform {
  transform(values: BookModel[], filter: string): BookModel[] {
    if (!filter || filter.length === 0) {
      return values;
    }

    if (values.length === 0) {
      return values;
    }

    return values.filter((value: BookModel) => {
      return value.title.toLowerCase().indexOf(filter.toLowerCase()) !== -1;
    });
  }
}
