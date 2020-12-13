# ContactManager

# Giriş
Merhaba,
Bu projede 2 farklı .net core projesi geliştirerek, basit bir telefon rehberi uygulaması + rapor servisi geliştirmeye çalıştım.
Öncelikle belirtmeliyim ki docker kullanarak geliştirdiğim ilk projeydi. Bu yüzden eksik ya da hatalı kısımlar olabilir. 

## Teknik
- Projede .net core 3.1 kullandım(daha önce 5.0 deneyimledim ancak daha stabil olabileceğini düşünerek 3.1 ile ilerledim.)
- Multilayered architecture yaklaşımını esas aldım. 
- CQRS, mediator ve repository patternlerini uyguladım.
- Auto mapper ile DTO ve uygulama varlıklarını birbirinden ayırdım.

## Containerlar
- MongoDB,
- Kafka,
- Zookeeper,
- DirectoryService > rehber mikroservisi
- ReportingService > rapor mikroservisi

Proje belirtmiş olduğum gibi henüz tamamlanmadı. Bu nedenle kafka entegrasyonu başarılı değil. 
Mevcutta çalışan sadece rehber üzerinde CRUD işlemleri ve bu kayıtların detaylarındaki CRUD işlemleridir.(ContactsController + ContactSectionsController)
Kafka entegrasyonu + rapor oluşturma daha sonra tamamlanması gerekiyor.
